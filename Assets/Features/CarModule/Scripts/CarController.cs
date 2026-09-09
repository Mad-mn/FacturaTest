using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarController : MonoBehaviour {
        [SerializeField] private Transform _view;
        [SerializeField] private Transform _turretSpawnTransform;
        [SerializeField] private Transform _cameraPoint;

        public Transform View =>
            _view;
        public Transform TurretSpawnTransform =>
            _turretSpawnTransform;
        
        public Transform CameraPoint =>
            _cameraPoint;
    }
}