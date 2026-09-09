using DG.Tweening;
using Features.LevelModule.Scripts;
using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarMover : ICarMover {
        private readonly CarModel _carModel;
        private const float MIN_INCLUSIVE = 0.5f;
        private const float ROTATION_DURATION = 2;

        private CarController _car;
        private LevelData _levelData;
        private bool _isMoving;
        private Sequence _forwardMoving;
        private Sequence _sideMoving;

        public CarMover(CarModel carModel) {
            _carModel = carModel;
        }

        public void Initialize(CarController car, LevelData levelData) {
            _car = car;
            _levelData = levelData;
        }

        public void Move() {
            if (_isMoving)
                return;

            _isMoving = true;
            float movingDuration = _levelData.MovingDistance / _levelData.CarSpeed;

            Moving(movingDuration);
        }

        private void Moving(float movingDuration) {
            _sideMoving = DOTween.Sequence();
            float oneSideDistance = _levelData.MovingDistance / _levelData.SideMovingFrequency;
            float sideMovingDuration = movingDuration / _levelData.SideMovingFrequency;
            for (int i = 0; i < _levelData.SideMovingFrequency; i++) {
                int sideMovingDirection = ((i + 1) % 2 == 0)
                    ? 1
                    : -1;

                float xPoint = Random.Range(MIN_INCLUSIVE, _levelData.SideMovingWight / 2) * sideMovingDirection;
                float zPoint = (i + 1) * oneSideDistance;
                Vector3 targetPoint = new Vector3(xPoint, 0, zPoint);
                _sideMoving.Append(_car.transform.DOMoveZ(targetPoint.z, sideMovingDuration)
                    .SetEase(Ease.Linear));

                _sideMoving.Join(_car.transform.DOMoveX(targetPoint.x, sideMovingDuration)
                    .SetEase(Ease.Linear));

                _sideMoving.Join(_car.transform.DOLookAt(targetPoint, ROTATION_DURATION));
                _sideMoving.OnComplete(()=> {
                                           Stop();
                                           _carModel.MovementComplete();
                                       });
            }
        }

        public void Stop() {
            _isMoving = false;
            _forwardMoving?.Kill();
            _forwardMoving = null;
            _sideMoving?.Kill();
            _sideMoving = null;
        }
    }
}