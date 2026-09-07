using Features.CarModule.Scripts;
using Features.TurretModule.Scripts;
using Features.ViewModule.Scripts;

namespace Features.GameSessionModule.Scripts {
    public class GameSessionService : IGameSessionService {
        private readonly ICarService _carService;
        private readonly IViewService _viewService;
        private readonly ITurretService _turretService;

        public GameSessionService(ICarService carService, IViewService viewService, ITurretService turretService) {
            _carService = carService;
            _viewService = viewService;
            _turretService = turretService;
        }
        
        public void StartGame() {
            _viewService.HideView(ViewType.StartView);
            _carService.StartMovement();    
            _turretService.StartFire();
        }
    }
}