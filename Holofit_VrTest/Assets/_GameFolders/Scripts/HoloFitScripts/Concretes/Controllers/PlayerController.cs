using HoloFit_VrTest.Abstracts.Controllers;
using HoloFit_VrTest.Abstracts.Inputs;
using HoloFit_VrTest.Abstracts.Movements;
using HoloFit_VrTest.Inputs;
using HoloFit_VrTest.Movements;
using UnityEngine;

namespace HoloFit_VrTest.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _horizontalSpeed = 1f;
        [SerializeField] float _verticalSpeed = 1f;
        
        public IInputReader Input { get; private set; }
        public IMover Mover { get; private set; }
        public IRotator RotatorX { get; private set; }
        public IRotator RotatorY { get; private set; }
        public float MoveSpeed => _moveSpeed;
        public float HorizontalSpeed => _horizontalSpeed;
        public float VerticalSpeed => _verticalSpeed;
        public Transform CameraTransform => Camera.main.transform;

        void Awake()
        {
            Input = new InputReaderKeyboardJoystick();
            Mover = new MoveWithCharacterController(this);
            RotatorX = new RotatorX(this);
            RotatorY = new RotatorY(this);
        }

        void Update()
        {
            Mover.Tick();
            RotatorX.Tick();
            RotatorY.Tick();
        }

        void FixedUpdate()
        {
            Mover.FixedTick();
        }
    }
}
