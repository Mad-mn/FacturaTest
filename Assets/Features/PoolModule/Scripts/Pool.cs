using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.BulletModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.PoolModule.Scripts {
    public abstract class Pool<TPoolable> : IPool<TPoolable> where TPoolable : IPoolable {
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;

        private Stack<TPoolable> _pool = new Stack<TPoolable>();
        private GameObject _prefab;
        protected abstract string PoolableName { get; }
        protected virtual int Size { get; } = 100;

        public Pool(IAddressableService addressableService, IInstantiator instantiator) {
            _addressableService = addressableService;
            _instantiator = instantiator;
        }
        
        public async UniTask Initialize() {
            await InitPool();
        }

        public TPoolable Get() {
            if (_pool.Count > 0) {
                TPoolable poolable = _pool.Pop();
                poolable.OnSpawned();
                return poolable;
            }
            else {
                TPoolable poolable = SpawnPoolable();
                poolable.OnSpawned();
                return poolable;
            }
        }

        public void Return(TPoolable bullet) {
            bullet.OnDespawned();
            _pool.Push(bullet);
        }

        private async UniTask InitPool() {
            _prefab = await _addressableService.GetAsset<GameObject>(PoolableName);
            for (int i = 0; i < Size; i++) {
                TPoolable poolable = SpawnPoolable();
                poolable.OnDespawned();
                _pool.Push(poolable);
            }
        }

        private TPoolable SpawnPoolable() {
            return _instantiator.InstantiatePrefabForComponent<TPoolable>(_prefab);
        }
    }
}