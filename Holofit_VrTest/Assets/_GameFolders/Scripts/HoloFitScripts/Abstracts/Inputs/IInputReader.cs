using UnityEngine;

namespace HoloFit_VrTest.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 MoveDirection { get; }
        Vector2 RotationDirection { get; }
    }
}