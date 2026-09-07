using System.Threading;
using Cysharp.Threading.Tasks;
using Features.CarModule.Scripts;
using Features.SceneLoaderModule.Scripts;
using Features.StartViewModule.Scripts;
using Features.TurretModule.Scripts;
using Features.ViewModule.Scripts;

namespace Features.StateMachineModule.Scripts.States {
    public class GameState : IState {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICarService _carService;
        private readonly IViewService _viewService;
        private readonly ITurretService _turretService;

        public GameState(IStateMachine stateMachine, ISceneLoader sceneLoader, ICarService carService, IViewService viewService,
            ITurretService turretService) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _carService = carService;
            _viewService = viewService;
            _turretService = turretService;
        }

        public void Enter() {
            InitGameSession()
                .Forget();
        }

        public void Exit() { }

        private async UniTaskVoid InitGameSession() {
            await LoadGameScene();
            await _carService.Initialize();
            await _turretService.Initialize();
            
            _viewService.HideView(ViewType.Loading);
            _viewService.ShowView<StartView>(ViewType.StartView);
        }

        private async UniTask LoadGameScene() {
            await _sceneLoader.LoadSceneAsync(SceneType.Game, CancellationToken.None);
        }
    }
}