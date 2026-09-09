using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Features.BulletModule.Scripts.Configs;
using Features.BulletModule.Scripts.Pools;
using Features.ConfigHandlerModule.Scripts;
using Features.PoolModule.Scripts;

namespace Features.BulletModule.Scripts {
    public class BulletService : IBulletService {
        private readonly IPool<Bullet> _bulletPool;
        private readonly IConfigHandler<BulletConfig> _bulletConfigHandler;
        
        private List<Bullet> _bullets = new List<Bullet>();

        public BulletService(IPool<Bullet> bulletPool, IConfigHandler<BulletConfig> bulletConfigHandler) {
            _bulletPool = bulletPool;
            _bulletConfigHandler = bulletConfigHandler;
        }
        
        public async UniTask Initialize() {
            await _bulletConfigHandler.Initialize();
            await _bulletPool.Initialize();
        }

        public Bullet Get() {
            Bullet bullet = _bulletPool.Get();
            _bullets.Add(bullet);
            bullet.OnHit += Return;
            bullet.OnFinishMovement += Return;
            return bullet;
        }

        public void Return(Bullet bullet) {
            bullet.OnHit -= Return;
            bullet.OnFinishMovement -= Return;
            if (_bullets.Contains(bullet)) {
                _bullets.Remove(bullet);
            }

            _bulletPool.Return(bullet);
        }

        public void Reset() {
            foreach (Bullet bullet in _bullets.ToList()) {
                Return(bullet);
            }
        }
    }
}