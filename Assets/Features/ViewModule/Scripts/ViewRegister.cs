using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Features.AddressableModule.Scripts;
using Features.LoadingViewModule.Scripts;
using Features.LoseViewModule.Scripts;
using Features.StartViewModule.Scripts;
using Features.ViewModule.Scripts.Configs;
using Features.WinViewModule.Scripts;
using UnityEngine;

namespace Features.ViewModule.Scripts {
    public class ViewRegister : IViewRegister {
        private readonly IAddressableService _addressableService;
        private Dictionary<ViewType, Type> _register;
        
        private ViewServiceConfig _viewServiceConfig;

        public ViewRegister(IAddressableService addressableService) {
            _addressableService = addressableService;
        }
        
        public async UniTask Initialize() {
            _viewServiceConfig = await _addressableService.GetAsset<ViewServiceConfig>(AssetConstants.VIEW_SERVICE_CONFIG);
            RegisterPresenters();
        }

        public Type GetPresenterType(ViewType viewType) {
            _register.TryGetValue(viewType, out Type viewPresenter);
            return viewPresenter;
        }

        public GameObject GetPrefab(ViewType viewType) {
            return _viewServiceConfig.ViewConfigs.FirstOrDefault(x => x.ViewType == viewType).Prefab;
        }

        private void RegisterPresenters() {
            _register = new Dictionary<ViewType, Type>() {
                {
                    ViewType.Start, typeof(StartPresenter)
                },
                {
                    ViewType.Loading, typeof(LoadingPresenter)
                },
                {
                    ViewType.Lose, typeof(LosePresenter)
                },
                {
                    ViewType.Win, typeof(WinPresenter)
                },
            };
        }
    }
}