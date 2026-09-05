using Zenject;

namespace Features.AddressableModule.Scripts.Installers {
    public class AddressableModuleInstaller : Installer<AddressableModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IAddressableService>().To<AddressableService>().AsSingle();
        }
    }
}