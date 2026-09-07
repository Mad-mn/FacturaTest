using UnityEngine;

namespace Features.ViewModule.Scripts {
    public abstract class BasePresenter<TView> : IPresenter where TView : MonoBehaviour, IView {
        protected TView View;

        protected BasePresenter(TView view) {
            View = view;
        }

        public virtual void Show() {
            View.gameObject.SetActive(true);
        }

        public virtual void Hide() {
            View.gameObject.SetActive(false);
        }
    }
}