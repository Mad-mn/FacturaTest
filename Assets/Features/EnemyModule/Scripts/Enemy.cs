using System;
using Features.CarModule.Scripts;
using Features.HealthModule.Scripts;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Features.EnemyModule.Scripts {
    public class Enemy : MonoBehaviour, IPoolable {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimatorController _animatorController;
        [SerializeField] private EnemyHealth _health;

        private bool _hasTarget;
        private Transform _target;
        public event Action<Enemy> OnDie;

        public void OnSpawned() {
            gameObject.SetActive(true);
            _health.Initialize(100f);
            _health.OnDie += Die;
        }

        public void OnDespawned() {
            ResetTarget();
            _animatorController.StopRun();
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out CarController car)) {
                _health.TakeDamage(100f);
                IHealth carHealth = car.GetComponent<IHealth>();
                carHealth.TakeDamage(50);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent(out CarController car)) {
                _target = car.transform;
                _hasTarget = true;
                _animatorController.StartRun();
            }
        }

        private void Update() {
            if (!_hasTarget)
                return;

            _agent.SetDestination(_target.position);
        }

        public void Stop() {
            _animatorController.StopRun();
            ResetTarget();
        }

        private void ResetTarget() {
            _hasTarget = false;
            _target = null;
        }

        private void Die() {
            OnDie?.Invoke(this);
        }
    }
}