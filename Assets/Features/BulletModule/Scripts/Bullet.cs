using System;
using DG.Tweening;
using Features.ConfigHandlerModule.Scripts;
using Features.ConfigHandlerModule.Scripts.Bullet;
using Features.HealthModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.BulletModule.Scripts {
    public class Bullet : MonoBehaviour, IPoolable {
        [SerializeField] private TrailRenderer _trailRenderer;
        private IConfigHandler<BulletConfig> _configHandler;
        private Sequence _moving;
        public event Action<Bullet> OnHit;
        public event Action<Bullet> OnFinishMovement;

        [Inject]
        public void InjectDependencies(IConfigHandler<BulletConfig> configHandler) {
            _configHandler = configHandler;
        }

        public void OnSpawned() {
            gameObject.SetActive(true);
        }

        public void OnDespawned() {
            gameObject.SetActive(false);
            _trailRenderer.Clear();
            _trailRenderer.enabled = false;
            _moving?.Kill();
            _moving = null;
        }

        public void Shot(Vector3 direction) {
            _trailRenderer.enabled = true;
            transform.rotation = Quaternion.LookRotation(direction);
            _moving = DOTween.Sequence();
            Vector3 destination = transform.position + (direction * Config.Range);
            _moving.Append(transform.DOMove(destination, Config.Range / Config.Speed)
                .OnComplete(() => OnFinishMovement?.Invoke(this)));
        }

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out IHealth health)) {
                health.TakeDamage(50);
            }

            OnHit?.Invoke(this);
            
        }

        private BulletConfig Config =>
            _configHandler.Config;
    }
}