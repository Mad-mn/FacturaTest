using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.CarModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.EnemyModule.Scripts.Configs;
using Features.LevelModule.Scripts;
using Features.PoolModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts {
    public class EnemyService : IEnemyService {
        private readonly IPool<Enemy> _pool;
        private readonly IConfigHandler<EnemySpawnConfig> _configHandler;
        private readonly IEnemySpawner _spawner;
        private readonly CarModel _carModel;

        public EnemyService(IPool<Enemy> pool, IConfigHandler<EnemySpawnConfig> configHandler, IEnemySpawner spawner,
            CarModel carModel) {
            _pool = pool;
            _configHandler = configHandler;
            _spawner = spawner;
            _carModel = carModel;
        }

        public async UniTask Initialize() {
            await _configHandler.Initialize();
            await _pool.Initialize();
            Spawn();
            _carModel.OnDie += OnLoseLevel;
        }

        private void Spawn() {
            _spawner.Spawn();
        }

        public void Respawn() {
            _spawner.Respawn();
        }

        private void OnLoseLevel() {
            foreach (Enemy enemy in _spawner.Enemies) {
                enemy.Stop();
            }
        }
    }
}