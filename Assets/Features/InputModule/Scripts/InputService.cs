using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.InputModule.Scripts {
    public class InputService : IInputService {
        public bool IsTap() {
#if UNITY_EDITOR && UNITY_ANDROID
            return Mouse.current != null && Mouse.current.leftButton.isPressed;
#endif

            return Touchscreen.current != null && Touchscreen.current.touches.Count > 0;
        }

        public Vector2 GetTapPosition() {
#if UNITY_EDITOR
            if (Mouse.current != null && Mouse.current.leftButton.isPressed) {
                return Mouse.current.position.ReadValue();
            }
#endif

            if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0) {
                return Touchscreen.current.primaryTouch.position.ReadValue();
            }

            return Vector2.zero;
        }
    }
}