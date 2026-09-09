using Features.AddressableModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts.Configs {
    public class EnemyConfigHandler<EnemyConfig> : ConfigHandler<EnemyConfig> where EnemyConfig : ScriptableObject {
        public EnemyConfigHandler(IAddressableService addressableService) : base(addressableService) { }
        protected override string ConfigName => AssetConstants.ENEMY_CONFIG;
    }
}