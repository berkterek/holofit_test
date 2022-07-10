using System.Collections;
using HoloFit_VrTest.Abstracts.Controllers;
using UnityEngine;

namespace HoloFit_VrTest.Movements
{
    public class FindAndLookPlayer : MonoBehaviour
    {
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
            _thisTransform.LookAt(_playerTranform.position);
            Vector3 eulerAngles = _thisTransform.eulerAngles;
            _thisTransform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
        }
    }    
}

