using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.CameraModule.Scripts {
    public interface ICameraService {
        Camera Camera { get; }
        UniTask Initialize();
    }
}