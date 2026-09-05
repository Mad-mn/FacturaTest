using Features.SceneLoaderModule.Scripts;
using Zenject;

namespace Features.SceneLoaderModule.Installers {
    public class SceneLoaderModuleInstaller : Installer<SceneLoaderModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}