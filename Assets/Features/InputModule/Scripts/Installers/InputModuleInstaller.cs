using Zenject;

namespace Features.InputModule.Scripts.Installers {
    public class InputModuleInstaller : Installer<InputModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }
    }
}