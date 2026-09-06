using Cysharp.Threading.Tasks;

namespace Features.LevelModule.Scripts {
    public interface ILevelService {
        UniTask Initialize();
        LevelData GetLevelData(int levelIndex);
        LevelData GetCurrentLevelData();
    }
}