using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.BulletModule.Scripts.Pools {
    public class BulletPool<TPoolable> : IBulletPool where TPoolable : IPoolable {
        private const int SIZE = 100;
        
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;
        
        private Stack<Bullet> _pool = new Stack<Bullet>();
        private GameObject _prefab;

        public BulletPool(IAddressableService addressableService, IInstantiator instantiator) {
            _addressableService = addressableService;
            _instantiator = instantiator;
        }
        
        public async UniTask Initialize() {
            await InitPool();
        }

        public Bullet Get() {
            if (_pool.Count > 0) {
                Bullet bullet = _pool.Pop();
                bullet.OnSpawned();
                return bullet;
            }
            else {
                Bullet bullet = SpawnBullet();
                bullet.OnSpawned();
                return bullet;
            }
        }

        public void Return(Bullet bullet) {
            bullet.OnDespawned();
            _pool.Push(bullet);
        }

        private async UniTask InitPool() {
            _prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.BULLET);
            for (int i = 0; i < SIZE; i++) {
                Bullet bullet = SpawnBullet();
                bullet.OnDespawned();
                _pool.Push(bullet);
            }
        }

        private Bullet SpawnBullet() {
            return _instantiator.InstantiatePrefabForComponent<Bullet>(_prefab);
        }
    }
}