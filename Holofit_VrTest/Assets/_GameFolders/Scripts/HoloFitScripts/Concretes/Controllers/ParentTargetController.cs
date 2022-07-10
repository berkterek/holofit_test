using HoloFit_VrTest.Abstracts.Controllers;
using UnityEngine;

namespace HoloFit_VrTest.Controllers
{
    public class ParentTargetController : TargetController
    {
        [SerializeField] GameObject _canvasObject;
        [SerializeField] FillerTargetController _fillerTargetController;

        void OnEnable()
        {
            _fillerTargetController.OnFillAmountFinished += HandleOnFillAmountFinished;
        }

        void OnDisable()
        {
            _fillerTargetController.OnFillAmountFinished -= HandleOnFillAmountFinished;
        }

        public override void SetTargetProcess(bool value)
        {
            if (_animator.GetBool("isNear") == value) return;

            _animator.SetBool("isNear", value);
        }
        
        void HandleOnFillAmountFinished()
        {
            _collider.enabled = false;
            _canvasObject.SetActive(false);
        }

        protected override void GetReference()
        {
            base.GetReference();
            
            if (_fillerTargetController == null)
            {
                _fillerTargetController = GetComponentInChildren<FillerTargetController>();
            }
        }
    }
}