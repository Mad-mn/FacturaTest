using System;
using Features.CarModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.EnemyModule.Scripts.Configs;
using Features.HealthModule.Scripts;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Features.EnemyModule.Scripts {
    public class Enemy : MonoBehaviour, IPoolable {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimatorController _animatorController;
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private Rigidbody _rigidbody;

        private IConfigHandler<EnemyConfig> _configHandler;
        private bool _hasTarget;
        private Transform _target;
        private bool _spawned;
        public event Action<Enemy> OnDie;

        [Inject]
        private void InjectDependencies(IConfigHandler<EnemyConfig> configHandler) {
            _configHandler = configHandler;
        }

        public void OnSpawned() {
            _spawned = true;
            gameObject.SetActive(true);
            _health.Initialize(Config.HealthMax);
            _health.OnDie += Die;
        }

        public void OnDespawned() {
            _spawned = false;
            Stop();
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out CarController car)) {
                _health.TakeDamage(Config.DamageFromCar);
                IHealth carHealth = car.GetComponent<IHealth>();
                carHealth.TakeDamage(Config.DamageFromCar);
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
            if (_agent.isOnNavMesh)
                _agent.isStopped = true;
            
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        private void Die() {
            OnDie?.Invoke(this);
        }
        
        private EnemyConfig Config => _configHandler.Config;
    }
}