using Features.AddressableModule.Scripts;
using Features.PoolModule.Scripts;
using Zenject;

namespace Features.EnemyModule.Scripts.Pools {
    public class EnemyPool<Enemy> : Pool<Enemy> where Enemy : IPoolable {
        public EnemyPool(IAddressableService addressableService, IInstantiator instantiator) : base(addressableService, instantiator) { }
        protected override string PoolableName =>
            AssetConstants.ENEMY;

        protected override int Size =>
            200;
    }
}