using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using UnityEngine;

namespace Features.ConfigHandlerModule.Scripts {
    public abstract class ConfigHandler<TConfig> : IConfigHandler<TConfig> where TConfig : ScriptableObject {
        private readonly IAddressableService _addressableService;
        protected abstract string ConfigName { get; }

        public ConfigHandler(IAddressableService addressableService) {
            _addressableService = addressableService;
        }
        
        public async UniTask Initialize() {
            await LoadConfig();
        }

        private async UniTask LoadConfig() {
            Config = await _addressableService.GetAsset<TConfig>(ConfigName);
        }

        public TConfig Config { get; private set; }
    }
}