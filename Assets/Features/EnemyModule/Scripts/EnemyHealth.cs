using System;
using DG.Tweening;
using Features.HealthModule.Scripts;
using UnityEngine;

namespace Features.EnemyModule.Scripts {
    public class EnemyHealth : MonoBehaviour, IHealth {
        [SerializeField] private EnemyAnimatorController _animatorController;
        [SerializeField] private HealthBar _healthBar;
        
        private float _currentHealth;
        private bool _isDead;

        public event Action OnDie;

        public void Initialize(float max) {
            _currentHealth = max;
            _healthBar.Setup(max);
            _isDead = false;
        }

        public void TakeDamage(float damage) {
            if(_isDead)
                return;
            
            if(damage<=0)
                return;
            
            _currentHealth -= damage;
            _healthBar.UpdateHealth(_currentHealth);
            _animatorController.PlayDamageAnimation(CheckForDie);
        }

        private void CheckForDie() {
            if(_currentHealth <= 0) {
                _isDead = true;
                OnDie?.Invoke();
            }
        }
    }
}