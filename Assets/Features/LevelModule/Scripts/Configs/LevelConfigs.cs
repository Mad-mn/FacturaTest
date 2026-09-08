using System.Collections.Generic;
using UnityEngine;

namespace Features.LevelModule.Scripts.Configs {
    [CreateAssetMenu(fileName = "LevelConfigs", menuName = "Game/LevelConfigs")]
    public class LevelConfigs : ScriptableObject {
        [SerializeField] private List<LevelData> _levelsData;
        
        public LevelData GetLevelData(int levelIndex) {
            if (_levelsData is null || _levelsData.Count == 0) {
                Debug.LogError("Level configs is empty");
                return null;
            }

            int levelId = levelIndex - 1;

            if (levelId < 0 || levelId >= _levelsData.Count) {
                return _levelsData[0];
            }

            return _levelsData[levelId];
        }
    }
}