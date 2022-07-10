using HoloFit_VrTest.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HoloFit_VrTest.Inputs
{
    public class InputReaderKeyboardJoystick : IInputReader
    {
        public Vector3 MoveDirection { get; private set; }
        public Vector2 RotationDirection { get; private set; }
        
        public InputReaderKeyboardJoystick()
        {
            GameInputActions input = new GameInputActions();

            input.PlayerWithoutVr.Move.performed += HandleOnMove;
            input.PlayerWithoutVr.Move.canceled += HandleOnMove;

            input.PlayerWithoutVr.Look.performed += HandleOnLook;
            input.PlayerWithoutVr.Look.canceled += HandleOnLook;
            
            input.Enable();
        }

        void HandleOnMove(InputAction.CallbackContext context)
        {
            var inputValue = context.ReadValue<Vector2>();
            MoveDirection = new Vector3(inputValue.x, 0f, inputValue.y);
        }
        
        void HandleOnLook(InputAction.CallbackContext context)
        {
            RotationDirection = context.ReadValue<Vector2>();
        }
    }
}