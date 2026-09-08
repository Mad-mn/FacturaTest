using Features.ConfigHandlerModule.Scripts;
using Features.LevelModule.Scripts.Configs;
using Zenject;

namespace Features.LevelModule.Scripts.Installers {
    public class LevelModuleInstaller : Installer<LevelModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IConfigHandler<LevelConfigs>>()
                .To<LevelConfigsHandler<LevelConfigs>>()
                .AsSingle();

            Container.Bind<ILevelService>()
                .To<LevelService>()
                .AsSingle();
        }
    }
}