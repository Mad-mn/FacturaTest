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

        public EnemyService(IPool<Enemy> pool, IConfigHandler<EnemySpawnConfig> configHandler, ILevelService levelService) {
            _pool = pool;
            _configHandler = configHandler;
            _levelService = levelService;
        }

        public async UniTask Initialize() {
            await _configHandler.Initialize();
            await _pool.Initialize();
            Spawn();
        }

        public void Respawn() { }

        private void Spawn() {
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
                }

                cellIndexes.Clear();
            }
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