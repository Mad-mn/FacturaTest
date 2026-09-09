using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.ConfigHandlerModule.Scripts;
using Features.EnemyModule.Scripts.Configs;
using Features.LevelModule.Scripts;
using Features.PoolModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts {
    public class EnemyService : IEnemyService {
        private readonly IPool<Enemy> _pool;
        private readonly IConfigHandler<EnemySpawnConfig> _configHandler;
        private readonly ILevelService _levelService;
        private readonly IEnemySpawner _spawner;

        public EnemyService(IPool<Enemy> pool, IConfigHandler<EnemySpawnConfig> configHandler, ILevelService levelService, IEnemySpawner spawner) {
            _pool = pool;
            _configHandler = configHandler;
            _levelService = levelService;
            _spawner = spawner;
        }

        public async UniTask Initialize() {
            await _configHandler.Initialize();
            await _pool.Initialize();
            Spawn();
        }

        private void Spawn() {
            _spawner.Spawn();
        }

        public void Respawn() {
            _spawner.Respawn();
        }
        
        private EnemySpawnConfig SpawnConfig =>
            _configHandler.Config;
    }
}