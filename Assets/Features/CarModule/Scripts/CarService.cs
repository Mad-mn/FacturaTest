using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.CarModule.Scripts {
    public class CarService : ICarService {
        private readonly IInstantiator _instantiator;
        private readonly IAddressableService _addressableService;

        private CarController _carController;

        public CarService(IInstantiator instantiator, IAddressableService addressableService) {
            _instantiator = instantiator;
            _addressableService = addressableService;
        }

        public async UniTask Initialize() {
            await SpawnCar();
        }

        public void StartMovement() { }

        private async UniTask SpawnCar() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.CAR);
            _carController = _instantiator.InstantiatePrefabForComponent<CarController>(prefab);
            _carController.transform.position = Vector3.zero;
        }
    }
}