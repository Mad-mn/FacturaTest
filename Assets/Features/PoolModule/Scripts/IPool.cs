using Cysharp.Threading.Tasks;
using Features.BulletModule.Scripts;
using Zenject;

namespace Features.PoolModule.Scripts {
    public interface IPool<TPoolable> where TPoolable : IPoolable {
        UniTask Initialize();
        TPoolable Get();
        void Return(TPoolable poolable);
    }
}