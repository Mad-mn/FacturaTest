using Features.CameraModule.Scripts;
using Features.InputModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.TurretModule.Scripts {
    public class TurretRotationController : ITurretRotationController, ITickable {
        private const float MAX_SIDE_ROTATION_ANGLE = 60f;
        private readonly IInputService _inputService;

        private TurretController _turretController;
        private bool _canRotate;

        public TurretRotationController(IInputService inputService) {
            _inputService = inputService;
        }
        
        public void Initialize(TurretController turretController) {
            _turretController = turretController;    
        }

        public void ChangeRotatingState(bool canRotate) {
            _canRotate = canRotate;
        }

        public void Tick() {
            if(!_canRotate)
                return;

            if(!_inputService.IsTap())
                return;

            Vector2 tapPosition = _inputService.GetTapPosition();
            if(tapPosition.x < 0 || tapPosition.x > Screen.width)
                return;
            
            float deltaX = tapPosition.x / Screen.width;
            float rotationAngle = (deltaX * MAX_SIDE_ROTATION_ANGLE * 2) - MAX_SIDE_ROTATION_ANGLE;
            _turretController.View.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}