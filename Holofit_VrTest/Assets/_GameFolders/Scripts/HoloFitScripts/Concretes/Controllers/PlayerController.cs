using HoloFit_VrTest.Abstracts.Combats;
using HoloFit_VrTest.Abstracts.Controllers;
using HoloFit_VrTest.Abstracts.Inputs;
using HoloFit_VrTest.Abstracts.Movements;
using HoloFit_VrTest.Combats;
using HoloFit_VrTest.Inputs;
using HoloFit_VrTest.Movements;
using UnityEngine;

namespace HoloFit_VrTest.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _selectDistance = 10f;
        [SerializeField] float _moveSpeed;
        [SerializeField] float _horizontalSpeed = 1f;
        [SerializeField] float _verticalSpeed = 1f;
        
        public IInputReader Input { get; private set; }
        public IMover Mover { get; private set; }
        public IRotator RotatorX { get; private set; }
        public IRotator RotatorY { get; private set; }
        public ISelection Selection { get; private set; }
        public float MoveSpeed => _moveSpeed;
        public float HorizontalSpeed => _horizontalSpeed;
        public float VerticalSpeed => _verticalSpeed;
        public Camera PlayerCamera { get; private set; }
        public float SelectDistance => _selectDistance;
        public LayerMask LayerMask => _layerMask;

        void Awake()
        {
            PlayerCamera = Camera.main;
            Input = new InputReaderKeyboardJoystick();
            Mover = new MoveWithCharacterController(this);
            RotatorX = new RotatorX(this);
            RotatorY = new RotatorY(this);
            Selection = new RaySelection(this);
        }

        void Update()
        {
            Mover.Tick();
            RotatorX.Tick();
            RotatorY.Tick();
            Selection.Tick();
        }

        void FixedUpdate()
        {
            Mover.FixedTick();
        }
    }
}
