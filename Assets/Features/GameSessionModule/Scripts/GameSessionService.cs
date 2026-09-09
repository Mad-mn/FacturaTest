using System;
using Features.BulletModule.Scripts;
using Features.CarModule.Scripts;
using Features.EnemyModule.Scripts;
using Features.LoadingViewModule.Scripts;
using Features.LoseViewModule.Scripts;
using Features.StartViewModule.Scripts;
using Features.TurretModule.Scripts;
using Features.ViewModule.Scripts;
using Features.WinViewModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.GameSessionModule.Scripts {
    public class GameSessionService : IGameSessionService, IInitializable, IDisposable {
        private readonly ICarService _carService;
        private readonly IViewService _viewService;
        private readonly ITurretService _turretService;
        private readonly IEnemyService _enemyService;
        private readonly CarModel _carModel;
        private readonly IBulletService _bulletService;
        private readonly ITurretRotationController _turretRotationController;

        public GameSessionService(ICarService carService, IViewService viewService, ITurretService turretService, IEnemyService enemyService,
            CarModel carModel, IBulletService bulletService, ITurretRotationController turretRotationController) {
            _carService = carService;
            _viewService = viewService;
            _turretService = turretService;
            _enemyService = enemyService;
            _carModel = carModel;
            _bulletService = bulletService;
            _turretRotationController = turretRotationController;
        }

        public void Initialize() {
            _carModel.OnDie += OnLoseLevel;
            _carModel.OnMovementComplete += OnWinLevel;
        }

        public void StartGame() {
            _viewService.HideView(ViewType.Start);
            _carService.StartMovement();
            _turretService.StartFire();
        }

        public void Restart() {
            _viewService.HideView(ViewType.Lose);
            _viewService.HideView(ViewType.Win);
            _bulletService.Reset();
            _carService.SetOnStart();
            _turretRotationController.Reset();
            _enemyService.Respawn();
            _viewService.ShowView<StartView>(ViewType.Start);
        }

        private void OnLoseLevel() {
            _viewService.ShowView<LoseView>(ViewType.Lose);
        }
        
        private void OnWinLevel() {
            _viewService.ShowView<WinView>(ViewType.Win);
        }

        public void Dispose() {
            _carModel.OnDie -= OnLoseLevel;
            _carModel.OnMovementComplete -= OnWinLevel;
        }
    }
}