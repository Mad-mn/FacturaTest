using System;
using DG.Tweening;
using Features.ConfigHandlerModule.Scripts;
using Features.ConfigHandlerModule.Scripts.Bullet;
using UnityEngine;
using Zenject;

namespace Features.BulletModule.Scripts {
    public class Bullet : MonoBehaviour, IPoolable {
        private IConfigHandler<BulletConfig> _configHandler;

        [SerializeField] private TrailRenderer _trailRenderer;

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
        }

        public void Shot(Vector3 direction) {
            _trailRenderer.enabled = true;

            Vector3 destination = transform.position + (direction * Config.Range);
            transform.DOMove(destination, Config.Range / Config.Speed)
                .OnComplete(() => OnFinishMovement?.Invoke(this));
        }

        private void OnCollisionEnter(Collision other) {
            OnHit?.Invoke(this);
        }

        private BulletConfig Config =>
            _configHandler.Config;
    }
}