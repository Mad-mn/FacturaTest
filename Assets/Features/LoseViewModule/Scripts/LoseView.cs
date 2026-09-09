using Features.ViewModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Features.LoseViewModule.Scripts {
    public class LoseView : MonoBehaviour, IView {
        [field: SerializeField] public Button RestartButton {get; private set;}
    }
}