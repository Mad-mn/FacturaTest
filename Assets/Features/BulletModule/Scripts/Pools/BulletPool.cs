using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.PoolModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.BulletModule.Scripts.Pools {
    public class BulletPool<Bullet> : Pool<Bullet> where Bullet : IPoolable {
        public BulletPool(IAddressableService addressableService, IInstantiator instantiator) : base(addressableService, instantiator) { }
        protected override string PoolableName =>
            AssetConstants.BULLET;
    }
}