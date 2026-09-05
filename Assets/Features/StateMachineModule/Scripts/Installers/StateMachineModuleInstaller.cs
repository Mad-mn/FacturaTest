using Zenject;

namespace Features.StateMachineModule.Scripts.Installers {
    public class StateMachineModuleInstaller : Installer<StateMachineModuleInstaller>
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<StateMachineStatesProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
        }
    }
}
