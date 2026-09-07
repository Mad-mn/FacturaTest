using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.LevelModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.CarModule.Scripts {
    public class CarService : ICarService {
        private readonly IInstantiator _instantiator;
        private readonly IAddressableService _addressableService;
        private readonly ICarMover _carMover;
        private readonly ILevelService _levelService;

        private CarController _carController;

        public CarService(IInstantiator instantiator, IAddressableService addressableService, ICarMover carMover,
            ILevelService levelService) {
            _instantiator = instantiator;
            _addressableService = addressableService;
            _carMover = carMover;
            _levelService = levelService;
        }

        public async UniTask Initialize() {
            await SpawnCar();
            LevelData levelData = _levelService.GetCurrentLevelData();
            _carMover.Initialize(_carController, levelData);
        }

        public void StartMovement() {
            _carMover.Move();
        }

        public Transform GetTurretSpawnTransform() {
                return _carController != null ? _carController.TurretSpawnTransform : null;
        }

        public void StopMovement() {
            _carMover.Stop();
        }

        private async UniTask SpawnCar() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.CAR);
            _carController = _instantiator.InstantiatePrefabForComponent<CarController>(prefab);
            _carController.transform.position = Vector3.zero;
        }
    }
}