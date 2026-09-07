using Features.ConfigHandlerModule.Scripts.Bullet;
using Features.ConfigHandlerModule.Scripts.Turret;
using Zenject;

namespace Features.ConfigHandlerModule.Scripts.Installers {
    public class ConfigHandlerModuleInstaller : Installer<ConfigHandlerModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IConfigHandler<BulletConfig>>()
                .To<BulletConfigHandler>()
                .AsSingle();
            
            Container.Bind<IConfigHandler<TurretConfig>>()
                .To<TurretConfigHandler>()
                .AsSingle();
        }
    }
}