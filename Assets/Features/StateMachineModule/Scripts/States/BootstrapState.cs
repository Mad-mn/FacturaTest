using Cysharp.Threading.Tasks;
using Features.CameraModule.Scripts;
using Features.CarModule.Scripts;
using UnityEngine;

namespace Features.StateMachineModule.Scripts.States {
    public class BootstrapState : IState {
        private readonly IStateMachine _stateMachine;
        private readonly ICameraService _cameraService;
        private readonly ICarService _carService;

        public BootstrapState(IStateMachine stateMachine, ICameraService cameraService, ICarService carService) {
            _stateMachine = stateMachine;
            _cameraService = cameraService;
            _carService = carService;
        }
        public void Enter() {
            Bootstrap();
        }

        public void Exit() {}

        private async UniTaskVoid Bootstrap() {

            await _cameraService.Initialize();
            await _carService.Initialize();
            _stateMachine.ChangeState<GameState>();
        }
    }
}