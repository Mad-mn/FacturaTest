using UnityEngine;

namespace Features.EnemyModule.Scripts.Configs {
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/EnemyConfig")]
    public class EnemyConfig : ScriptableObject {
        [field: SerializeField] public float HealthMax { get; private set; }
        [field: SerializeField] public float DamageToCar { get; private set; }
        [field: SerializeField] public float DamageFromCar { get; private set; }
    }
}