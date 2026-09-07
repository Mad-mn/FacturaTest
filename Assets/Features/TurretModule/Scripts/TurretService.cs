using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.CarModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.TurretModule.Scripts {
    public class TurretService : ITurretService {
        private readonly ICarService _carService;
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;
        private readonly ITurretRotationController _turretRotationController;

        private TurretController _turretController;

        public TurretService(ICarService carService, IAddressableService addressableService, IInstantiator instantiator,
            ITurretRotationController turretRotationController) {
            _carService = carService;
            _addressableService = addressableService;
            _instantiator = instantiator;
            _turretRotationController = turretRotationController;
        }
        
        public async UniTask Initialize() {
            await SpawnTurret();
            _turretRotationController.Initialize(_turretController);
        }

        public void StartFire() {
            _turretRotationController.ChangeRotatingState(true);
        }

        public void StopFire() {
        }

        private async UniTask SpawnTurret() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.TURRET);
            _turretController = _instantiator.InstantiatePrefabForComponent<TurretController>(prefab, _carService.GetTurretSpawnTransform());
        }
    }
}