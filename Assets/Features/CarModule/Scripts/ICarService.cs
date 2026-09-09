using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.CarModule.Scripts {
    public interface ICarService {
        UniTask Initialize();
        void StartMovement();
        Transform GetTurretSpawnTransform();
        void SetOnStart();
    }
}