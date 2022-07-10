using HoloFit_VrTest.Abstracts.Controllers;
using HoloFit_VrTest.Abstracts.Movements;
using UnityEngine;

namespace HoloFit_VrTest.Movements
{
    public class MoveWithCharacterController : IMover
    {
        readonly CharacterController _characterController;
        readonly IPlayerController _playerController;
        readonly Transform _transform;
        readonly Vector3 _zero;
        readonly float _gravityValue = -9.81f;

        Vector3 _moveDirection;
        Vector3 _playerVelocity;
        bool _groundedPlayer;

        public MoveWithCharacterController(IPlayerController playerController)
        {
            _characterController = playerController.transform.GetComponent<CharacterController>();
            _playerController = playerController;
            _transform = playerController.transform;
            _zero = Vector3.zero;
        }

        public void Tick()
        {
            _moveDirection = _playerController.Input.MoveDirection * (Time.deltaTime * _playerController.MoveSpeed);
        }

        public void FixedTick()
        {
            GravityProcess();
            MovementProcess();
        }

        private void GravityProcess()
        {
            _groundedPlayer = _characterController.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity);
        }

        private void MovementProcess()
        {
            if (_moveDirection == _zero) return;

            Vector3 worldPosition = _transform.TransformDirection(_moveDirection);
            Vector3 movement = worldPosition * (Time.deltaTime * _playerController.MoveSpeed);

            _characterController.Move(movement);
        }
    }
}