using UnityEngine;
using Zenject;

namespace Features.PoolModule.Scripts.Installers {
    public class PoolModuleInstaller : Installer<PoolModuleInstaller> {
        public const string POOL_PARENT_ID = "Pools";
        public override void InstallBindings() {
            GameObject poolParent = Container.CreateEmptyGameObject(POOL_PARENT_ID);
            Container.Bind<Transform>()
                .WithId(POOL_PARENT_ID)
                .FromInstance(poolParent.transform)
                .AsSingle();
        }
    }
}