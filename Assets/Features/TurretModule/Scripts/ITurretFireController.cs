namespace Features.TurretModule.Scripts {
    public interface ITurretFireController {
        void Initialize(TurretController turretController);
        void StartFire();
        void StopFire();
    }
}