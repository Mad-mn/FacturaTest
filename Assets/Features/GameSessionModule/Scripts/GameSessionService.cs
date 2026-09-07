using Features.CarModule.Scripts;
using Features.ViewModule.Scripts;

namespace Features.GameSessionModule.Scripts {
    public class GameSessionService : IGameSessionService {
        private readonly ICarService _carService;
        private readonly IViewService _viewService;

        public GameSessionService(ICarService carService, IViewService viewService) {
            _carService = carService;
            _viewService = viewService;
        }
        
        public void StartGame() {
            _viewService.HideView(ViewType.StartView);
            _carService.StartMovement();    
        }
    }
}