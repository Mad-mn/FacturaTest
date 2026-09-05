using System;
using System.Collections.Generic;
using Features.StateMachineModule.Scripts.States;
using UnityEngine;
using Zenject;

namespace Features.StateMachineModule.Scripts {
    public class StateMachineStatesProvider : IStateMachineStatesProvider, IInitializable {
        private readonly IInstantiator _instantiator;
        private Dictionary<Type, IState> _states = new();
        
        public StateMachineStatesProvider(IInstantiator instantiator) {
            _instantiator = instantiator;
        }

        public void Initialize() {
            _states = new() {
                {
                    typeof(BootstrapState), _instantiator.Instantiate<BootstrapState>()
                }, {
                    typeof(GameState), _instantiator.Instantiate<GameState>()
                }
            };
        }

        public IState GetState<T>() {
            if (_states.TryGetValue(typeof(T), out IState state)) {
                return state;
            }
            else {
                throw new Exception($"State {typeof(T)} not found");
            }
        }
    }
}