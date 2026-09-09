using System;

namespace Features.CarModule.Scripts {
    public class CarModel {
        public event Action OnDie;
        public event Action OnMovementComplete;
        
        public void Die() {
            OnDie?.Invoke();
        }

        public void MovementComplete() {
            OnMovementComplete?.Invoke();
        }
    }
}