using Cysharp.Threading.Tasks;
using Features.CameraModule.Scripts;
using UnityEngine;

namespace Features.StateMachineModule.Scripts.States {
    public class BootstrapState : IState {
        private readonly IStateMachine _stateMachine;
        private readonly ICameraService _cameraService;

        public BootstrapState(IStateMachine stateMachine, ICameraService cameraService) {
            _stateMachine = stateMachine;
            _cameraService = cameraService;
        }
        public void Enter() {
            Bootstrap();
        }

        public void Exit() {}

        private async UniTaskVoid Bootstrap() {

            await _cameraService.Initialize();
            _stateMachine.ChangeState<GameState>();
        }
    }
}