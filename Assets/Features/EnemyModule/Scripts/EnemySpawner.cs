using System.Collections.Generic;
using Features.ConfigHandlerModule.Scripts;
using Features.EnemyModule.Scripts.Configs;
using Features.LevelModule.Scripts;
using Features.PoolModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts {
    public class EnemySpawner : IEnemySpawner {
        private readonly ILevelService _levelService;
        private readonly IPool<Enemy> _pool;
        private readonly IConfigHandler<EnemySpawnConfig> _configHandler;

        private List<Enemy> _enemies = new List<Enemy>();

        public IReadOnlyList<Enemy> Enemies =>
            _enemies;

        public EnemySpawner(ILevelService levelService, IPool<Enemy> pool, IConfigHandler<EnemySpawnConfig> configHandler) {
            _levelService = levelService;
            _pool = pool;
            _configHandler = configHandler;
        }

        public void Spawn() {
            float roadLength = _levelService.GetCurrentLevelData()
                .MovingDistance - SpawnConfig.StartSpawnOffset;

            float roadWidth = _levelService.GetCurrentLevelData()
                .RoadWidth;

            float cellWightPerOneEnemy = roadWidth / SpawnConfig.MaxCountInRow;
            List<int> cellIndexes = new List<int>(SpawnConfig.MaxCountInRow);

            int rowCount = Mathf.RoundToInt(roadLength / SpawnConfig.MinZDistance);
            for (int i = 0; i < rowCount; i++) {
                int enemyInRow = GetEnemyCount();
                float enemyZ = (i * SpawnConfig.MinZDistance) + SpawnConfig.StartSpawnOffset;

                for (int j = 0; j < enemyInRow; j++) {
                    Enemy enemy = _pool.Get();

                    int enemyCellIndex = 0;
                    do {
                        enemyCellIndex = Random.Range(0, SpawnConfig.MaxCountInRow);
                    }
                    while (cellIndexes.Contains(enemyCellIndex));

                    cellIndexes.Add(enemyCellIndex);
                    float enemyX = SpawnConfig.LeftRoadBoarder + enemyCellIndex * cellWightPerOneEnemy;
                    enemy.transform.position = new Vector3(enemyX, 0, enemyZ);
                    enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                    enemy.OnDie += OnDie;
                    _enemies.Add(enemy);
                }

                cellIndexes.Clear();
            }
        }

        private void OnDie(Enemy enemy) {
            enemy.OnDie -= OnDie;
            if (_enemies.Contains(enemy))
                _enemies.Remove(enemy);

            _pool.Return(enemy);
        }

        public void Respawn() {
            foreach (Enemy enemy in _enemies) {
                enemy.OnDie -= OnDie;
                _pool.Return(enemy);
            }

            _enemies.Clear();
            Spawn();
        }

        private int GetEnemyCount() {
            int count = 0;

            for (int i = 0; i < SpawnConfig.MaxCountInRow; i++) {
                if (i < SpawnConfig.MinCountInRow) {
                    count++;
                    continue;
                }

                if (Random.value <= SpawnConfig.ChanceForNextEnemy)
                    count++;
                else
                    break;
            }

            return count;
        }

        private EnemySpawnConfig SpawnConfig =>
            _configHandler.Config;
    }
}