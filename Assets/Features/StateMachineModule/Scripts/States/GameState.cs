using System.Threading;
using Cysharp.Threading.Tasks;
using Features.CarModule.Scripts;
using Features.SceneLoaderModule.Scripts;

namespace Features.StateMachineModule.Scripts.States {
    public class GameState : IState {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICarService _carService;

        public GameState(IStateMachine stateMachine, ISceneLoader sceneLoader, ICarService carService) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _carService = carService;
        }
        public void Enter() {
            InitGameSession().Forget();
        }

        public void Exit() {
        }

        private async UniTaskVoid InitGameSession() {
            await LoadGameScene();
            await _carService.Initialize();
            _carService.StartMovement();
        }
        
        private async UniTask LoadGameScene() {
            await _sceneLoader.LoadSceneAsync(SceneType.Game, CancellationToken.None);
        }
    }
}