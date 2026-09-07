using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.CarModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.ConfigHandlerModule.Scripts.Turret;
using UnityEngine;
using Zenject;

namespace Features.TurretModule.Scripts {
    public class TurretService : ITurretService {
        private readonly ICarService _carService;
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;
        private readonly ITurretRotationController _turretRotationController;
        private readonly ITurretFireController _turretFireController;
        private readonly IConfigHandler<TurretConfig> _turretConfigHandler;

        private TurretController _turretController;

        public TurretService(ICarService carService, IAddressableService addressableService, IInstantiator instantiator,
            ITurretRotationController turretRotationController, ITurretFireController turretFireController, IConfigHandler<TurretConfig> turretConfigHandler) {
            _carService = carService;
            _addressableService = addressableService;
            _instantiator = instantiator;
            _turretRotationController = turretRotationController;
            _turretFireController = turretFireController;
            _turretConfigHandler = turretConfigHandler;
        }
        
        public async UniTask Initialize() {
            await SpawnTurret();
            await _turretConfigHandler.Initialize();
            _turretRotationController.Initialize(_turretController);
            _turretFireController.Initialize(_turretController);
        }

        public void StartFire() {
            _turretRotationController.ChangeRotatingState(true);
            _turretFireController.StartFire();
        }

        public void StopFire() {
            _turretRotationController.ChangeRotatingState(false);
            _turretFireController.StopFire();
        }

        private async UniTask SpawnTurret() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.TURRET);
            _turretController = _instantiator.InstantiatePrefabForComponent<TurretController>(prefab, _carService.GetTurretSpawnTransform());
        }
    }
}