using System.Collections;
using HoloFit_VrTest.Abstracts.Controllers;
using UnityEngine;

namespace HoloFit_VrTest.Movements
{
    public class FindAndLookPlayer : MonoBehaviour
    {
        [SerializeField] Transform _parentTransform;
        [SerializeField] float _maxDistance = 0.5f;
        [SerializeField] float _moveSpeed = 1f;
        Transform _playerTranform;
        Transform _thisTransform;

        void Awake()
        {
            _thisTransform = transform;
        }

        IEnumerator Start()
        {
            while (_playerTranform == null)
            {
                _playerTranform = GameObject.FindWithTag("Player").GetComponent<IPlayerController>().transform;
                yield return null;
            }
        }

        void Update()
        {
            RotationProcess();
            MoveProcess();
        }

        void MoveProcess()
        {
            Vector3 parentPositionWithY = new Vector3(_parentTransform.position.x, 0f, _parentTransform.position.z);
            Vector3 thisTransformWithY = new Vector3(_thisTransform.position.x, 0f, _thisTransform.position.z);
            bool maxDistanceResult = Vector3.Distance(parentPositionWithY, thisTransformWithY) < _maxDistance;

            float moveSpeed = Time.deltaTime * _moveSpeed;
            float yPosition = _thisTransform.position.y;
            
            if(maxDistanceResult)
            {
                _thisTransform.position = Vector3.MoveTowards(_thisTransform.position, _playerTranform.position, moveSpeed);
            }
            else
            {
                _thisTransform.position = Vector3.MoveTowards(_thisTransform.position, _parentTransform.position, moveSpeed);
            }

            _thisTransform.position = new Vector3(_thisTransform.position.x, yPosition, _thisTransform.position.z);
        }

        private void RotationProcess()
        {
            _thisTransform.LookAt(_playerTranform.position);
            Vector3 eulerAngles = _thisTransform.eulerAngles;
            _thisTransform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
        }
    }    
}

