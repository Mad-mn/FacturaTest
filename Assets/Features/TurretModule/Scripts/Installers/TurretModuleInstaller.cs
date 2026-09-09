using Features.ConfigHandlerModule.Scripts;
using Features.TurretModule.Scripts.Configs;
using Zenject;

namespace Features.TurretModule.Scripts.Installers {
    public class TurretModuleInstaller : Installer<TurretModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IConfigHandler<TurretConfig>>()
                .To<TurretConfigHandler>()
                .AsSingle();

            Container.Bind<ITurretService>()
                .To<TurretService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<TurretRotationController>()
                .AsSingle();

            Container.Bind<ITurretFireController>()
                .To<TurretFireController>()
                .AsSingle();
        }
    }
}