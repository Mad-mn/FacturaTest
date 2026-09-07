using UnityEngine;

namespace Features.InputModule.Scripts {
    public interface IInputService {
        bool IsTap();
        Vector2 GetTapPosition();
    }
}