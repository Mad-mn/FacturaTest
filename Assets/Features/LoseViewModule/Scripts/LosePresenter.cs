using Features.GameSessionModule.Scripts;
using Features.ViewModule.Scripts;
using UnityEngine;

namespace Features.LoseViewModule.Scripts {
    public class LosePresenter : BasePresenter<LoseView> {
        private readonly IGameSessionService _gameSessionService;
        public LosePresenter(LoseView view, IGameSessionService gameSessionService) : base(view) {
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

        public void OnRestartButtonClicked() {
            _gameSessionService.Restart();
        }
    }
}