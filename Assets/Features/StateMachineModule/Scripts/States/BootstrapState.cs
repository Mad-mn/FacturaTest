using Cysharp.Threading.Tasks;
using Features.CameraModule.Scripts;
using Features.CarModule.Scripts;
using Features.LevelModule.Scripts;
using Features.LoadingViewModule.Scripts;
using Features.ViewModule.Scripts;
using UnityEngine;

namespace Features.StateMachineModule.Scripts.States {
    public class BootstrapState : IState {
        private readonly IStateMachine _stateMachine;
        private readonly ICameraService _cameraService;
        private readonly ICarService _carService;
        private readonly ILevelService _levelService;
        private readonly IViewService _viewService;

        public BootstrapState(IStateMachine stateMachine, ICameraService cameraService, ICarService carService,
            ILevelService levelService, IViewService viewService) {
            _stateMachine = stateMachine;
            _cameraService = cameraService;
            _carService = carService;
            _levelService = levelService;
            _viewService = viewService;
        }
        public void Enter() {
            Bootstrap();
        }

        public void Exit() {}

        private async UniTaskVoid Bootstrap() {
            await _cameraService.Initialize();
            await _viewService.Initialize();
            _viewService.ShowView<LoadingView>(ViewType.Loading);
            await _levelService.Initialize();
            _stateMachine.ChangeState<GameState>();
        }
    }
}