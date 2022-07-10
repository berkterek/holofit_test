using HoloFit_VrTest.Abstracts.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace HoloFit_VrTest.Controllers
{
    public class FillerTargetController : TargetController
    {
        [SerializeField] Image _fillerImage;
        [SerializeField] float _fillerSpeed;

        bool _canFill;
        bool _isPlayOneTime = false;
        public event System.Action OnFillAmountFinished;

        void Update()
        {
            if (_isPlayOneTime) return;
            
            if (!_canFill)
            {
                if(_fillerImage.fillAmount != 0) _fillerImage.fillAmount = 0f;
                return;
            }

            _fillerImage.fillAmount += _fillerSpeed * Time.deltaTime;

            if (_fillerImage.fillAmount == 1f)
            {
                _isPlayOneTime = true;
                _collider.enabled = false;
                _animator.SetTrigger("dying");
                OnFillAmountFinished?.Invoke();
            }
        }

        protected override void GetReference()
        {
            base.GetReference();
            
            if (_fillerImage == null)
            {
                _fillerImage = GetComponent<Image>();
            }
        }
        
        public override void SetTargetProcess(bool value)
        {
            _canFill = value;
        }
    }
}