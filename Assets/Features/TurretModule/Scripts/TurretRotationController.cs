using Features.CameraModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.InputModule.Scripts;
using Features.TurretModule.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Features.TurretModule.Scripts {
    public class TurretRotationController : ITurretRotationController, ITickable {
        private readonly IInputService _inputService;
        private readonly IConfigHandler<TurretConfig> _turretConfigHandler;

        private TurretController _turretController;
        private bool _canRotate;

        public TurretRotationController(IInputService inputService, IConfigHandler<TurretConfig> turretConfigHandler) {
            _inputService = inputService;
            _turretConfigHandler = turretConfigHandler;
        }
        
        public void Initialize(TurretController turretController) {
            _turretController = turretController;    
        }

        public void ChangeRotatingState(bool canRotate) {
            _canRotate = canRotate;
        }

        public void Reset() {
            _turretController.View.transform.forward = Vector3.forward;
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
            float rotationAngle = (deltaX * Config.MaxSideRotationAngle * 2) - Config.MaxSideRotationAngle;
            _turretController.View.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        
        private TurretConfig Config => _turretConfigHandler.Config;

    }
}