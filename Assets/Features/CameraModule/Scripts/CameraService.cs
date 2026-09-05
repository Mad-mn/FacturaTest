using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Features.CameraModule.Scripts {
    public class CameraService : ICameraService{
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;
        public Camera Camera { get; private set; }

        public CameraService([CanBeNull] IAddressableService addressableService, IInstantiator instantiator) {
            _addressableService = addressableService;
            _instantiator = instantiator;
        }
        
        public async UniTask Initialize() {
            await SpawnCamera();
        }

        private async UniTask SpawnCamera() {
            GameObject cameraPrefab = await _addressableService.GetAsset<GameObject>(AssetConstants.CAMERA_PREFAB);
            Camera = _instantiator.InstantiatePrefabForComponent<Camera>(cameraPrefab);
        }
    }
}