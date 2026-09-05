namespace Features.CarModule.Scripts {
    public interface ICarMover {
        void Initialize(CarController car);
        void Move();
        void Stop();
    }
}