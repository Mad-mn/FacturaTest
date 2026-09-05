using Cysharp.Threading.Tasks;

namespace Features.CarModule.Scripts {
    public interface ICarService {
        UniTask Initialize();
        void StartMovement();
    }
}