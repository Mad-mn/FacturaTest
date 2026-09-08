using UnityEngine;

namespace Features.EnemyModule.Scripts.Configs {
    [CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "Enemy/EnemySpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject {
        [field: SerializeField] public float MinZDistance { get; private set; }
        [field: SerializeField] public int MinCountInRow  { get; private set; }
        [field: SerializeField] public int MaxCountInRow  { get; private set; }
        [field: SerializeField, Range(0, 1)] public float ChanceForNextEnemy  { get; private set; }
        [field: SerializeField] public float LeftRoadBoarder  { get; private set; }
        [field: SerializeField] public float StartSpawnOffset  { get; private set; }
        
    }
}