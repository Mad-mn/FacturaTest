using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.CarModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.EnemyModule.Scripts.Configs;
using Features.LevelModule.Scripts;
using Features.PoolModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts {
    public class EnemyService : IEnemyService, IDisposable {
        private readonly IPool<Enemy> _pool;
        private readonly IConfigHandler<EnemySpawnConfig> _spawnConfigHandler;
        private readonly IConfigHandler<EnemyConfig> _enemyConfigHandler;
        private readonly IEnemySpawner _spawner;
        private readonly CarModel _carModel;

        public EnemyService(IPool<Enemy> pool, IConfigHandler<EnemySpawnConfig> spawnConfigHandler, IEnemySpawner spawner,
            CarModel carModel, IConfigHandler<EnemyConfig> enemyConfigHandler) {
            _pool = pool;
            _spawnConfigHandler = spawnConfigHandler;
            _enemyConfigHandler = enemyConfigHandler;
            _spawner = spawner;
            _carModel = carModel;
        }

        public async UniTask Initialize() {
            await _spawnConfigHandler.Initialize();
            await _enemyConfigHandler.Initialize();
            await _pool.Initialize();
            Spawn();
            _carModel.OnDie += OnLoseLevel;
            _carModel.OnMovementComplete += OnWinLevel;
        }

        private void Spawn() {
            _spawner.Spawn();
        }

        public void Respawn() {
            _spawner.Respawn();
        }

        private void OnLoseLevel() {
            StopAllEnemies();
        }

        private void OnWinLevel() {
            StopAllEnemies();
        }

        private void StopAllEnemies() {
            foreach (Enemy enemy in _spawner.Enemies) {
                enemy.Stop();
            }
        }

        public void Dispose() {
            _carModel.OnDie -= OnLoseLevel;
            _carModel.OnMovementComplete -= OnWinLevel;
        }
    }
}