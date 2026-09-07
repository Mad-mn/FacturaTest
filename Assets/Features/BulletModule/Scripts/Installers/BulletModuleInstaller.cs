using Features.BulletModule.Scripts.Pools;
using Zenject;

namespace Features.BulletModule.Scripts.Installers {
    public class BulletModuleInstaller : Installer<BulletModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IBulletPool>()
                .To<BulletPool<Bullet>>()
                .AsSingle();

            Container.Bind<IBulletService>()
                .To<BulletService>()
                .AsSingle();
        }
    }
}