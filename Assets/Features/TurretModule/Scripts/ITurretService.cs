using Cysharp.Threading.Tasks;

namespace Features.TurretModule.Scripts {
    public interface ITurretService {
        UniTask Initialize();
        void StartFire();
        void StopFire();
    }
}