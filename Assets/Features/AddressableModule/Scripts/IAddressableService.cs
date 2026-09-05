using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.AddressableModule.Scripts {
    public interface IAddressableService {
        UniTask<T> GetAsset<T>(string assetName);
        void ReleaseAsset(string assetName);
    }
}