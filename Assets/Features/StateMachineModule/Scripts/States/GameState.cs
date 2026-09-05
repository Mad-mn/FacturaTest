using System.Threading;
using Cysharp.Threading.Tasks;
using Features.SceneLoaderModule.Scripts;

namespace Features.StateMachineModule.Scripts.States {
    public class GameState : IState {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public GameState(IStateMachine stateMachine, ISceneLoader sceneLoader) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter() {
            LoadGameScene().Forget();
        }

        public void Exit() {
        }
        
        private async UniTaskVoid LoadGameScene() {
            await _sceneLoader.LoadSceneAsync(SceneType.Game, CancellationToken.None);
        }
    }
}