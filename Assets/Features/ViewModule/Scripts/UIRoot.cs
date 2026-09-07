using UnityEngine;

namespace Features.ViewModule.Scripts {
    public class UIRoot : MonoBehaviour{
        [SerializeField] private Canvas _canvas;

        public Canvas Canvas =>
            _canvas;

        public void SetupCamera(Camera cam) {
            _canvas.worldCamera = cam;
        }
    }
}