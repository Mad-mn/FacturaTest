using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.ViewModule.Scripts.Factories {
    public interface IViewFactory {
        IPresenter CreateView<T>(ViewType viewType, Transform parent) where T : MonoBehaviour, IView;
    }
}