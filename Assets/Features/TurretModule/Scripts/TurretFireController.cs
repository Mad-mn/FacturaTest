using System.Collections;
using DG.Tweening;
using Feature.CoroutineRunnerModule.Scripts;
using Features.BulletModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.ConfigHandlerModule.Scripts.Turret;
using UnityEngine;

namespace Features.TurretModule.Scripts {
    public class TurretFireController : ITurretFireController {
        private readonly IBulletService _bulletService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IConfigHandler<TurretConfig> _turretConfigHandler;

        private TurretController _turretController;
        private bool _canFire;

        public TurretFireController(IBulletService bulletService, ICoroutineRunner coroutineRunner, IConfigHandler<TurretConfig> turretConfigHandler) {
            _bulletService = bulletService;
            _coroutineRunner = coroutineRunner;
            _turretConfigHandler = turretConfigHandler;
        }

        public void Initialize(TurretController turretController) {
            _turretController = turretController;
        }

        public void StartFire() {
            if(_canFire)
                return;
            
            _canFire = true;
            _coroutineRunner.StartRoutine(FireRoutine());
        }

        public void StopFire() {
            _canFire = false;
            _coroutineRunner.Stop(FireRoutine());
        }

        private IEnumerator FireRoutine() {
            WaitForSeconds wait = new WaitForSeconds(Config.FireRate);
            
            while (_canFire) {
                Bullet bullet = _bulletService.Get();
                
                bullet.transform.position = _turretController.BulletStartPoint.position;
                bullet.Shot(_turretController.View.transform.forward);
                yield return wait;
            }
        }
        
        private TurretConfig Config => _turretConfigHandler.Config;
    }
}