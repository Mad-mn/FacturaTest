using DG.Tweening;

namespace Features.CarModule.Scripts {
    public class CarMover : ICarMover {
        private CarController _car;
        private bool _isMoving;
        private Sequence _moving;

        public void Initialize(CarController car) {
            _car = car;
        }

        public void Move() {
            if(_isMoving)
                return;
            
            _isMoving = true;
            _moving = DOTween.Sequence();
            _moving.Append(_car.transform.DOMoveZ(150, 60).SetEase(Ease.Linear).OnComplete(Stop));
        }

        public void Stop() {
            _isMoving = false;
            _moving?.Kill();
            _moving = null;
        }
    }
}