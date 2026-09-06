using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;

namespace Features.LevelModule.Scripts {
    public class LevelService : ILevelService {
        private readonly IAddressableService _addressableService;

        private LevelConfigsHandler _levelConfigsHandler;

        public LevelService(IAddressableService addressableService) {
            _addressableService = addressableService;
        }

        public async UniTask Initialize() {
            _levelConfigsHandler = await _addressableService.GetAsset<LevelConfigsHandler>(AssetConstants.LEVEL_CONFIGS_HANDLER);
        }

        public LevelData GetLevelData(int levelIndex) {
            return _levelConfigsHandler.GetLevelConfig(levelIndex).LevelData;
        }

        public LevelData GetCurrentLevelData() {
            /// Take current level index from saves
            return GetLevelData(1);
        }
    }
}