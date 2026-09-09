using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Features.CameraModule.Scripts {
    public class CameraService : ICameraService {
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;
        public Camera Camera { get; private set; }
        
        public CameraService(IAddressableService addressableService, IInstantiator instantiator) {
            _addressableService = addressableService;
            _instantiator = instantiator;
        }

        public async UniTask Initialize() {
            await SpawnCamera();
        }

        public async UniTask<CarCamera> CreateCarCamera() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.CAR_CAMERA);
            return _instantiator.InstantiatePrefabForComponent<CarCamera>(prefab);
        }

        private async UniTask SpawnCamera() {
            GameObject cameraPrefab = await _addressableService.GetAsset<GameObject>(AssetConstants.CAMERA_PREFAB);
            Camera = _instantiator.InstantiatePrefabForComponent<Camera>(cameraPrefab);
        }
    }
}