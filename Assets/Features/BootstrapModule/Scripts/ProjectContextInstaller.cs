using Features.AddressableModule.Scripts.Installers;
using Features.CameraModule.Scripts.Installers;
using Features.CarModule.Scripts.Installers;
using Features.LevelModule.Scripts.Installers;
using Features.SceneLoaderModule.Installers;
using Features.StateMachineModule.Scripts.Installers;
using Features.ViewModule.Scripts.Installers;
using UnityEngine;
using Zenject;

namespace Features.BootstrapModule.Scripts {
    [CreateAssetMenu(fileName = "ProjectContextInstaller", menuName = "Installers/ProjectContextInstaller")]
    public class ProjectContextInstaller : ScriptableObjectInstaller<ProjectContextInstaller> {
        public override void InstallBindings() {
            AddressableModuleInstaller.Install(Container);
            CameraModuleInstaller.Install(Container);
            CarModuleInstaller.Install(Container);
            LevelModuleInstaller.Install(Container);
            StateMachineModuleInstaller.Install(Container);
            SceneLoaderModuleInstaller.Install(Container);
            ViewModuleInstaller.Install(Container);
        }
    }
}