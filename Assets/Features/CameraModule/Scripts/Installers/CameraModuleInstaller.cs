using Zenject;

namespace Features.CameraModule.Scripts.Installers {
    public class CameraModuleInstaller : Installer<CameraModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<ICameraService>().To<CameraService>().AsSingle();
        }
    }
}