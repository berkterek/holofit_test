using HoloFit_VrTest.Abstracts.Inputs;
using HoloFit_VrTest.Abstracts.Movements;
using UnityEngine;

namespace HoloFit_VrTest.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader Input { get; }
        IMover Mover { get; }
        IRotator RotatorX { get; }
        IRotator RotatorY { get; }
        float MoveSpeed { get; }
        float HorizontalSpeed { get; }
        float VerticalSpeed { get; }
        Camera PlayerCamera { get; }
        float SelectDistance { get; }
        LayerMask LayerMask { get; }
    }
}