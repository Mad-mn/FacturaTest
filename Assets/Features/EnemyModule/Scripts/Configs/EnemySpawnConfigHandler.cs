using Features.AddressableModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts.Configs {
    public class EnemySpawnConfigHandler<EnemySpawnConfig> :ConfigHandler<EnemySpawnConfig> where EnemySpawnConfig : ScriptableObject {
        public EnemySpawnConfigHandler(IAddressableService addressableService) : base(addressableService) { }
        protected override string ConfigName => AssetConstants.ENEMY_SPAWN_CONFIG;
    }
}