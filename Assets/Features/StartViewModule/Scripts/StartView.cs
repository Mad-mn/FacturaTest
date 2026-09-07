using Features.ViewModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Features.StartViewModule.Scripts {
    public class StartView : MonoBehaviour, IView {
        [field: SerializeField] public Button StartButton { get; private set; }
    }
}