using HoloFit_VrTest.Abstracts.Controllers;
using HoloFit_VrTest.Abstracts.Movements;
using UnityEngine;

namespace HoloFit_VrTest.Movements
{
    public class RotatorX : IRotator
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;
        
        public RotatorX(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = _playerController.transform;
        }
        
        public void Tick()
        {
            float direction = _playerController.Input.RotationDirection.x;

            if (direction == 0f) return;
            
            _transform.Rotate(Vector3.up * direction * Time.deltaTime * _playerController.HorizontalSpeed);
        }
    }
}

