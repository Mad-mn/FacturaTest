using Features.ViewModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Features.WinViewModule.Scripts {
    public class WinView : MonoBehaviour, IView {
        [field: SerializeField] public Button RestartButton { get; private set; } 
    }
}