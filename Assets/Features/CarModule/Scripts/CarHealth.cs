using System;
using Features.CarModule.Scripts.Installers;
using Features.HealthModule.Scripts;
using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarHealth : MonoBehaviour, IHealth {
        
        [SerializeField] private CarAnimationController _animationController;
        [SerializeField] private HealthBar _healthBar;
        
        public event Action OnDie;

        private float _maxHealth;
        private float _currentHealth;
        private bool _isDead;

        public void Initialize(float max) {
            _maxHealth = max;
            _currentHealth = _maxHealth;
            _healthBar.Setup(_maxHealth);
            _isDead = false;
        }

        public void TakeDamage(float damage) {
            if(_isDead)
                return;
            
            if(damage<=0)
                return;
            
            _currentHealth -= damage;
            _healthBar.UpdateHealth(_currentHealth);
            _animationController.PlayDamageAnimation(CheckForDie);
        }

        private void CheckForDie() {
            if (_currentHealth <= 0 && !_isDead) {
                _isDead = true;
                OnDie?.Invoke();
            }
        }
    }
}