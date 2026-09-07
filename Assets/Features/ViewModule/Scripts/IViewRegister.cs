using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.ViewModule.Scripts {
    public interface IViewRegister {
        UniTask Initialize();
        Type GetPresenterType(ViewType viewType);
        GameObject GetPrefab(ViewType viewType);
    }
}