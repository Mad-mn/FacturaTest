using Features.AddressableModule.Scripts;
using Features.PoolModule.Scripts;
using Features.PoolModule.Scripts.Installers;
using UnityEngine;
using Zenject;

namespace Features.EnemyModule.Scripts.Pools {
    public class EnemyPool<Enemy> : Pool<Enemy> where Enemy : IPoolable {
        public EnemyPool(IAddressableService addressableService, IInstantiator instantiator,
            [Inject(Id = PoolModuleInstaller.POOL_PARENT_ID)] Transform poolParent) : base(addressableService, instantiator, poolParent) { }

        protected override string PoolableName =>
            AssetConstants.ENEMY;

        protected override int Size =>
            80;
    }
}