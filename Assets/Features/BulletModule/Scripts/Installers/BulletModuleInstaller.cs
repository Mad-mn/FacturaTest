using Features.BulletModule.Scripts.Configs;
using Features.BulletModule.Scripts.Pools;
using Features.ConfigHandlerModule.Scripts;
using Features.PoolModule.Scripts;
using Zenject;

namespace Features.BulletModule.Scripts.Installers {
    public class BulletModuleInstaller : Installer<BulletModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IConfigHandler<BulletConfig>>()
                .To<BulletConfigHandler>()
                .AsSingle();

            Container.Bind<IPool<Bullet>>()
                .To<BulletPool<Bullet>>()
                .AsSingle();

            Container.Bind<IBulletService>()
                .To<BulletService>()
                .AsSingle();
        }
    }
}