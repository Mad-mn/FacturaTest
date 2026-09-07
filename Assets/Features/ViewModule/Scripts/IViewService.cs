using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.ViewModule.Scripts {
    public interface IViewService {
        UniTask Initialize();
        void ShowView<T>(ViewType viewType) where T : MonoBehaviour, IView;
        void HideView(ViewType viewType);
    }
}