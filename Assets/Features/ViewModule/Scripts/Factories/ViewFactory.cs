using System;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using UnityEngine;
using Zenject;

namespace Features.ViewModule.Scripts.Factories {
    public class ViewFactory : IViewFactory {
        private readonly IInstantiator _instantiator;
        private readonly IViewRegister _viewRegister;

        public ViewFactory(IInstantiator instantiator, IViewRegister viewRegister) {
            _instantiator = instantiator;
            _viewRegister = viewRegister;
        }

        public IPresenter CreateView<T>(ViewType viewType, Transform parent) where T : MonoBehaviour, IView {
            Type presenterType = _viewRegister.GetPresenterType(viewType);
            IView view = SpawnView<T>(viewType, parent);
            return _instantiator.Instantiate(presenterType, new object[] {
                view
            }) as IPresenter;
        }

        private IView SpawnView<T>(ViewType viewType, Transform parent) where T : MonoBehaviour, IView {
            GameObject prefab = _viewRegister.GetPrefab(viewType);
            return _instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
        }
    }
}