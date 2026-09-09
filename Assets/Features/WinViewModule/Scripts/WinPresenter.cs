using Features.GameSessionModule.Scripts;
using Features.ViewModule.Scripts;

namespace Features.WinViewModule.Scripts {
    public class WinPresenter : BasePresenter<WinView> {
        private readonly IGameSessionService _gameSessionService;
        public WinPresenter(WinView view, IGameSessionService gameSessionService) : base(view) {
            _gameSessionService = gameSessionService;
        }

        public override void Show() {
            base.Show();
            View.RestartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        public override void Hide() {
            base.Hide();
            View.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked() {
            _gameSessionService.Restart();
        }
    }
}