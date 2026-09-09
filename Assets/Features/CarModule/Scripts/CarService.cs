using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.CameraModule.Scripts;
using Features.LevelModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.CarModule.Scripts {
    public class CarService : ICarService {
        private readonly Vector3 _startPosition = Vector3.zero;
        private readonly IInstantiator _instantiator;
        private readonly IAddressableService _addressableService;
        private readonly ICarMover _carMover;
        private readonly ILevelService _levelService;
        private readonly ICameraService _cameraService;
        private readonly CarModel _carModel;

        private CarController _carController;
        private CarCamera _carCamera;
        private LevelData _levelData;

        public CarService(IInstantiator instantiator, IAddressableService addressableService, ICarMover carMover, ILevelService levelService,
            ICameraService cameraService, CarModel carModel) {
            _instantiator = instantiator;
            _addressableService = addressableService;
            _carMover = carMover;
            _levelService = levelService;
            _cameraService = cameraService;
            _carModel = carModel;
        }

        public async UniTask Initialize() {
            _levelData = _levelService.GetCurrentLevelData();
            await SpawnCar();
            await SpawnCarCamera();
            _carMover.Initialize(_carController, _levelData);
        }

        private async UniTask SpawnCarCamera() {
            _carCamera = await _cameraService.CreateCarCamera();
            _carCamera.SetupTarget(_carController.CameraPoint.transform);
        }

        public Transform GetTurretSpawnTransform() {
            return _carController != null
                ? _carController.TurretSpawnTransform
                : null;
        }

        public void StartMovement() {
            _carMover.Move();
        }

        public void StopMovement() {
            _carMover.Stop();
        }

        public void SetOnStart() {
            _carController.transform.position = _startPosition;
            _carController.transform.forward = Vector3.forward;
            _carController.Reset();
            _carController.Initialize(_levelData.CarHealth);
        }

        private async UniTask SpawnCar() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.CAR);
            _carController = _instantiator.InstantiatePrefabForComponent<CarController>(prefab);
            SetOnStart();
            _carController.OnDie += Die;
        }

        private void Die() {
            StopMovement();
            _carModel.Die();
        }
    }
}