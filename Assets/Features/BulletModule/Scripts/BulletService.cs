using Cysharp.Threading.Tasks;
using Features.BulletModule.Scripts.Pools;
using Features.ConfigHandlerModule.Scripts;
using Features.ConfigHandlerModule.Scripts.Bullet;

namespace Features.BulletModule.Scripts {
    public class BulletService : IBulletService {
        private readonly IBulletPool _bulletPool;
        private readonly IConfigHandler<BulletConfig> _bulletConfigHandler;

        public BulletService(IBulletPool bulletPool, IConfigHandler<BulletConfig> bulletConfigHandler) {
            _bulletPool = bulletPool;
            _bulletConfigHandler = bulletConfigHandler;
        }
        
        public async UniTask Initialize() {
            await _bulletConfigHandler.Initialize();
            await _bulletPool.Initialize();
        }

        public Bullet Get() {
            Bullet bullet = _bulletPool.Get();
            bullet.OnHit += Return;
            bullet.OnFinishMovement += Return;
            return bullet;
        }

        public void Return(Bullet bullet) {
            bullet.OnHit -= Return;
            bullet.OnFinishMovement -= Return;

            _bulletPool.Return(bullet);
        }
    }
}