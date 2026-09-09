using System;

namespace Features.HealthModule.Scripts {
    public interface IHealth {
        event Action OnDie;
        void Initialize(float max);
        void TakeDamage(float damage);
        
        
    }
}