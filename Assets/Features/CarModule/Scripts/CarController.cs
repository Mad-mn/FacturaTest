using System;
using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarController : MonoBehaviour {
        [SerializeField] private Transform _view;
        [SerializeField] private Transform _turretSpawnTransform;
        [SerializeField] private Transform _cameraPoint;
        [SerializeField] private CarHealth _health;

        public event Action OnDie;

        public Transform View =>
            _view;
        public Transform TurretSpawnTransform =>
            _turretSpawnTransform;

        public Transform CameraPoint =>
            _cameraPoint;

        public void Initialize(float carHealth) {
            _health.Initialize(carHealth);
            _health.OnDie += Die;
        }

        private void Die() {
            OnDie?.Invoke();
        }
    }
}