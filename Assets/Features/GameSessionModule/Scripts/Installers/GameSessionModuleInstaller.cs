using Zenject;

namespace Features.GameSessionModule.Scripts.Installers {
    public class GameSessionModuleInstaller : Installer<GameSessionModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IGameSessionService>()
                .To<GameSessionService>()
                .AsSingle();
        }
    }
}