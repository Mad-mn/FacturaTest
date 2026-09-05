using UnityEngine;

namespace Features.StateMachineModule.Scripts.States {
    public class BootstrapState : IState {
        private readonly IStateMachine _stateMachine;

        public BootstrapState(IStateMachine stateMachine) {
            _stateMachine = stateMachine;
        }
        public void Enter() {
            Bootstrap();
        }

        public void Exit() {
            
        }

        private void Bootstrap() {
            _stateMachine.ChangeState<GameState>();
        }
    }
}