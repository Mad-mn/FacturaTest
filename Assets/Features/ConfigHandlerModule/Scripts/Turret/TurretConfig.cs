using UnityEngine;

namespace Features.ConfigHandlerModule.Scripts.Turret {
    [CreateAssetMenu(fileName = "TurretConfig", menuName = "Turret/TurretConfig")]
    public class TurretConfig : ScriptableObject{
       [field: SerializeField] public float FireRate = 1;
       [field: SerializeField] public float MaxSideRotationAngle = 60;
    }
}