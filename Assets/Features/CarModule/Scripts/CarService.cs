using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.CarModule.Scripts {
    public class CarService : ICarService {
        private readonly IInstantiator _instantiator;
        private readonly IAddressableService _addressableService;
        private readonly ICarMover _carMover;

        private CarController _carController;

        public CarService(IInstantiator instantiator, IAddressableService addressableService, ICarMover carMover) {
            _instantiator = instantiator;
            _addressableService = addressableService;
            _carMover = carMover;
        }

        public async UniTask Initialize() {
            await SpawnCar();
            _carMover.Initialize(_carController);
        }

        public void StartMovement() {
            _carMover.Move();
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