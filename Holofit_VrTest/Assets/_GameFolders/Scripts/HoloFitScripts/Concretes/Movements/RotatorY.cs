using HoloFit_VrTest.Abstracts.Controllers;
using HoloFit_VrTest.Abstracts.Movements;
using UnityEngine;

namespace HoloFit_VrTest.Movements
{
    public class RotatorY : IRotator
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;

        float _tilt;
        
        public RotatorY(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.CameraTransform;
        }
        
        public void Tick()
        {
            float direction = _playerController.Input.RotationDirection.y;

            if (direction == 0f) return;
            
            direction *= _playerController.VerticalSpeed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30f, 70f);
            _transform.localRotation = Quaternion.Euler(_tilt,0f,0f);
        }
    }
}