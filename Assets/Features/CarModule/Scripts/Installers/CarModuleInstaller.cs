using Zenject;

namespace Features.CarModule.Scripts.Installers {
    public class CarModuleInstaller : Installer<CarModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<ICarService>().To<CarService>().AsSingle();
            Container.Bind<ICarMover>().To<CarMover>().AsSingle();
        }
    }
}