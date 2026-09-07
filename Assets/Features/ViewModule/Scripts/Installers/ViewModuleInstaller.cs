using Features.ViewModule.Scripts.Factories;
using Zenject;

namespace Features.ViewModule.Scripts.Installers {
    public class ViewModuleInstaller : Installer<ViewModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IViewService>()
                .To<ViewService>()
                .AsSingle();
            
            Container.Bind<IViewFactory>()
                .To<ViewFactory>()
                .AsSingle();

            Container.Bind<IViewRegister>()
                .To<ViewRegister>()
                .AsSingle();
        }
    }
}