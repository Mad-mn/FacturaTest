using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.CameraModule.Scripts;
using Features.ViewModule.Scripts.Factories;
using UnityEngine;
using Zenject;

namespace Features.ViewModule.Scripts {
    public class ViewService : IViewService {
        private readonly IAddressableService _addressableService;
        private readonly IInstantiator _instantiator;
        private readonly ICameraService _cameraService;
        private readonly IViewFactory _viewFactory;
        private readonly IViewRegister _viewRegister;

        private readonly Dictionary<ViewType, IPresenter> _cachedViews = new();
        private readonly Dictionary<ViewType, IPresenter> _showedViews = new();

        private UIRoot _uiRoot;

        public ViewService(IAddressableService addressableService, IInstantiator instantiator, ICameraService cameraService, IViewFactory viewFactory,
            IViewRegister viewRegister) {
            _addressableService = addressableService;
            _instantiator = instantiator;
            _cameraService = cameraService;
            _viewFactory = viewFactory;
            _viewRegister = viewRegister;
        }

        public async UniTask Initialize() {
            await LoadUIRoot();
            await _viewRegister.Initialize();
        }

        private async UniTask LoadUIRoot() {
            GameObject prefab = await _addressableService.GetAsset<GameObject>(AssetConstants.UI_ROOT);
            _uiRoot = _instantiator.InstantiatePrefabForComponent<UIRoot>(prefab);
            _uiRoot.SetupCamera(_cameraService.Camera);
        }

        public void ShowView<T>(ViewType viewType) where T : MonoBehaviour, IView {
            if (_cachedViews.TryGetValue(viewType, out IPresenter presenter)) {
                presenter.Show();
                _showedViews.Add(viewType, presenter);
                return;
            }

            IPresenter newPresenter = CreateView<T>(viewType);
            newPresenter.Show();
            _showedViews.Add(viewType, newPresenter);
        }

        public void HideView(ViewType viewType) {
            if (_showedViews.TryGetValue(viewType, out IPresenter presenter)) {
                presenter.Hide();
                _showedViews.Remove(viewType);
            }
        }

        private IPresenter CreateView<T>(ViewType viewType) where T : MonoBehaviour, IView {
            IPresenter newPresenter = _viewFactory.CreateView<T>(viewType, _uiRoot.Canvas.transform);
            _cachedViews.Add(viewType, newPresenter);
            return newPresenter;
        }
    }
}