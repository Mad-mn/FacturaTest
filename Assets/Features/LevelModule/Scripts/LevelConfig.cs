using UnityEngine;

namespace Features.LevelModule.Scripts {
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
    public class LevelConfig : ScriptableObject {
        [SerializeField] private LevelData _levelData;
        
        public LevelData LevelData => _levelData;
    }
}