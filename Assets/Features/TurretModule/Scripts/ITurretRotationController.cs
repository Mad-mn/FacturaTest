namespace Features.TurretModule.Scripts {
    public interface ITurretRotationController {
        void Initialize(TurretController turretController);
        void ChangeRotatingState(bool canRotate);
    }
}