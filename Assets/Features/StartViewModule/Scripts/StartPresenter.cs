using Features.CarModule.Scripts;
using Features.GameSessionModule.Scripts;
using Features.ViewModule.Scripts;

namespace Features.StartViewModule.Scripts {
    public class StartPresenter : BasePresenter<StartView> {
        private readonly IGameSessionService _gameSessionService;

        public StartPresenter(StartView view, IGameSessionService gameSessionService) : base(view) {
            _gameSessionService = gameSessionService;
        }

        public override void Show() {
            base.Show();
            View.StartButton.onClick.AddListener(OnStartButtonClick);
        }

        public override void Hide() {
            base.Hide();
            View.StartButton.onClick.RemoveListener(OnStartButtonClick);
        }

        private void OnStartButtonClick() {
            _gameSessionService.StartGame();
        }
    }
}