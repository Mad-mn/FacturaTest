using Zenject;

namespace Features.StateMachineModule.Scripts.Installers {
    public class StateMichineModuleInstaller : Installer<StateMichineModuleInstaller>
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<StateMachineStatesProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
        }
    }
}
