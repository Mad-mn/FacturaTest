using Features.LevelModule.Scripts;

namespace Features.CarModule.Scripts {
    public interface ICarMover {
        void Initialize(CarController car, LevelData levelData);
        void Move();
        void Stop();
    }
}