using Features.StateMachineModule.Scripts.States;

namespace Features.StateMachineModule.Scripts {
    public interface IStateMachineStatesProvider {
        IState GetState<T>();
    }
}