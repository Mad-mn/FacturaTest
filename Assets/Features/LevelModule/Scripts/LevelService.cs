using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.ConfigHandlerModule.Scripts;
using Features.LevelModule.Scripts.Configs;

namespace Features.LevelModule.Scripts {
    public class LevelService : ILevelService {
        private readonly IConfigHandler<LevelConfigs> _configHandler;

        public LevelService(IConfigHandler<LevelConfigs> configHandler) {
            _configHandler = configHandler;
        }

        public async UniTask Initialize() {
             await _configHandler.Initialize();
        }

        public LevelData GetLevelData(int levelIndex) {
            return LevelConfigs.GetLevelData(levelIndex);
        }

        public LevelData GetCurrentLevelData() {
            /// Take current level index from saves
            return GetLevelData(1);
        }

        private LevelConfigs LevelConfigs =>
            _configHandler.Config;
    }
}