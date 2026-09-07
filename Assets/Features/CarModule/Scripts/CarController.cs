using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarController : MonoBehaviour {
        [SerializeField] private Transform _view;
        [SerializeField] private Transform _turretSpawnTransform;

        public Transform View =>
            _view;
        public Transform TurretSpawnTransform =>
            _turretSpawnTransform;
    }
}