using UnityEngine;

namespace Features.TurretModule.Scripts {
    public class TurretController : MonoBehaviour {
        [SerializeField] private Transform _view;
        [SerializeField] private Transform _bulletStartPoint;
        
        public Transform View =>
            _view;
        
        public Transform BulletStartPoint =>
            _bulletStartPoint;
    }
}