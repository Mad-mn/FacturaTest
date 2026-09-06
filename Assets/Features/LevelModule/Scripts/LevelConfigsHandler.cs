using System.Collections.Generic;
using UnityEngine;

namespace Features.LevelModule.Scripts {
    [CreateAssetMenu(fileName = "LevelConfigsHandler", menuName = "Game/LevelConfigsHandler")]
    public class LevelConfigsHandler : ScriptableObject {
        [SerializeField] private List<LevelConfig> _levelConfigs;

        public LevelConfig GetLevelConfig(int levelIndex) {
            if (_levelConfigs is null || _levelConfigs.Count == 0) {
                Debug.LogError("Level configs handler are empty");
                return null;
            }

            int levelId = levelIndex - 1;

            if (levelId < 0 || levelId >= _levelConfigs.Count) {
                return _levelConfigs[0];
            }

            return _levelConfigs[levelId];
        }
    }
}