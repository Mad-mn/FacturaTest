using System.Threading;
using Cysharp.Threading.Tasks;
using Features.BulletModule.Scripts;
using Features.CarModule.Scripts;
using Features.EnemyModule.Scripts;
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
        private readonly IBulletService _bulletService;
        private readonly IEnemyService _enemyService;

        public GameState(IStateMachine stateMachine, ISceneLoader sceneLoader, ICarService carService, IViewService viewService,
            ITurretService turretService, IBulletService bulletService, IEnemyService enemyService) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _carService = carService;
            _viewService = viewService;
            _turretService = turretService;
            _bulletService = bulletService;
            _enemyService = enemyService;
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
            await _bulletService.Initialize();
            await _enemyService.Initialize();
            
            _viewService.HideView(ViewType.Loading);
            _viewService.ShowView<StartView>(ViewType.StartView);
        }

        private async UniTask LoadGameScene() {
            await _sceneLoader.LoadSceneAsync(SceneType.Game, CancellationToken.None);
        }
    }
}