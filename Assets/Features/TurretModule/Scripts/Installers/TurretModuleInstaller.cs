using Zenject;

namespace Features.TurretModule.Scripts.Installers {
    public class TurretModuleInstaller : Installer<TurretModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<ITurretService>()
                .To<TurretService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<TurretRotationController>()
                .AsSingle();
        }
    }
}