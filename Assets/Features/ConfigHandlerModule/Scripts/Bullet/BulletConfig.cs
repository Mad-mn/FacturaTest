using UnityEngine;

namespace Features.ConfigHandlerModule.Scripts.Bullet {
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Bullet/BulletConfig")]
    public class BulletConfig : ScriptableObject {
        [field: SerializeField] public float Speed = 20;
        [field: SerializeField] public float Damage = 10;
        [field: SerializeField] public float Range = 50;
    }
}