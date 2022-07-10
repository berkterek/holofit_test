using System.Collections.Generic;
using HoloFit_VrTest.Abstracts.Combats;
using HoloFit_VrTest.Abstracts.Controllers;
using UnityEngine;

namespace HoloFit_VrTest.Combats
{
    public class RaySelection : ISelection
    {
        readonly IPlayerController _playerController;
        readonly List<ITargetController> _targetControllers;

        public RaySelection(IPlayerController playerController)
        {
            _playerController = playerController;
            _targetControllers = new List<ITargetController>();
        }

        public void Tick()
        {
            Ray ray = _playerController.PlayerCamera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray, 10f,_playerController.LayerMask);

            
            if (raycastHits.Length != 0)
            {
                foreach (var raycastHit in raycastHits)
                {
                    if (raycastHit.collider.TryGetComponent(out ITargetController targetController))
                    {
                        targetController.SetTargetProcess(true);

                        if (!_targetControllers.Contains(targetController))
                        {
                            _targetControllers.Add(targetController);
                        }
                    }    
                }
            }
            else
            {
                if (_targetControllers.Count == 0) return;

                foreach (var targetController in _targetControllers)
                {
                    targetController.SetTargetProcess(false);
                }
                
                _targetControllers.Clear();
            }
        }
    }
}