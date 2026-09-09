using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.PoolModule.Scripts;
using Features.PoolModule.Scripts.Installers;
using UnityEngine;
using Zenject;

namespace Features.BulletModule.Scripts.Pools {
    public class BulletPool<Bullet> : Pool<Bullet> where Bullet : IPoolable {
        public BulletPool(IAddressableService addressableService, IInstantiator instantiator,
            [Inject(Id = PoolModuleInstaller.POOL_PARENT_ID)] Transform poolParent) : base(addressableService, instantiator, poolParent) { }

        protected override string PoolableName =>
            AssetConstants.BULLET;
    }
}