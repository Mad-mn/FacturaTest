using Cysharp.Threading.Tasks;

namespace Features.BulletModule.Scripts {
    public interface IBulletService {
        UniTask Initialize();
        Bullet Get();
        void Return(Bullet bullet);
        void Reset();
    }
}