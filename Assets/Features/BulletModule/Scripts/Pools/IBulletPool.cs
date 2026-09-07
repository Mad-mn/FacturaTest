using Cysharp.Threading.Tasks;

namespace Features.BulletModule.Scripts.Pools {
    public interface IBulletPool {
        UniTask Initialize();
        Bullet Get();
        void Return(Bullet bullet);
    }
}