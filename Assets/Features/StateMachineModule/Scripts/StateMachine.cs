using Features.StateMachineModule.Scripts.States;
using Zenject;

namespace Features.StateMachineModule.Scripts {
    public class StateMachine : IStateMachine, IInitializable {
        private readonly IStateMachineStatesProvider _statesProvider;

        private IState _currentState;
        
        public StateMachine(IStateMachineStatesProvider statesProvider) {
            _statesProvider = statesProvider;
        }
        
        public void ChangeState<T>() {
            _currentState?.Exit();
            _currentState = _statesProvider.GetState<T>();
            _currentState?.Enter();
        }

        public void Initialize() {
            ChangeState<BootstrapState>();
        }
    }
}