using Cysharp.Threading.Tasks;

namespace Features.EnemyModule.Scripts {
    public interface IEnemyService {
        UniTask Initialize();
        void Respawn();
    }
}