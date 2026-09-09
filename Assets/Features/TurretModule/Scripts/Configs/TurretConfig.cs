using UnityEngine;

namespace Features.TurretModule.Scripts.Configs {
    [CreateAssetMenu(fileName = "TurretConfig", menuName = "Turret/TurretConfig")]
    public class TurretConfig : ScriptableObject{
       [field: SerializeField] public float FireRate = 1;
       [field: SerializeField] public float MaxSideRotationAngle = 60;
    }
}