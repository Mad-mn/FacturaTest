using Zenject;

namespace Features.LevelModule.Scripts.Installers {
    public class LevelModuleInstaller : Installer<LevelModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<ILevelService>().To<LevelService>().AsSingle();
        }
    }
}