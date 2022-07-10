using UnityEngine;

namespace HoloFit_VrTest.Abstracts.Controllers
{
    public abstract class TargetController : MonoBehaviour, ITargetController
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected Collider _collider;
        
        public abstract void SetTargetProcess(bool value);

        protected void Awake()
        {
            GetReference();
        }

        protected void OnValidate()
        {
            GetReference();
        }

        protected virtual void GetReference()
        {
            if (_collider == null)
            {
                _collider = GetComponent<Collider>();
            }
        }
    }
}