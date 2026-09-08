using Features.AddressableModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using UnityEngine;

namespace Features.LevelModule.Scripts.Configs {
    [CreateAssetMenu(fileName = "LevelConfigsHandler", menuName = "Game/LevelConfigsHandler")]
    public class LevelConfigsHandler<LevelConfigs> : ConfigHandler<LevelConfigs> where LevelConfigs : ScriptableObject {

        public LevelConfigsHandler(IAddressableService addressableService) : base(addressableService){}

        protected override string ConfigName => AssetConstants.LEVEL_CONFIGS;
    }
}