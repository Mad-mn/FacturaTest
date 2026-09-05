using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Features.AddressableModule.Scripts {
    public class AddressableService : IAddressableService {
        private readonly Dictionary<(string, Type), AsyncOperationHandle> _loadedAssets = new();

        public async UniTask<T> GetAsset<T>(string assetName) {
            var key = (assetName, typeof(T));

            if (_loadedAssets.TryGetValue(key, out var existingHandle)) {
                if (existingHandle.IsValid()) {
                    if (!existingHandle.IsDone) {
                        await existingHandle.ToUniTask();
                    }

                    if (existingHandle.Status == AsyncOperationStatus.Succeeded) {
                        return (T)existingHandle.Result;
                    }
                }

                _loadedAssets.Remove(key);
            }

            var handle = Addressables.LoadAssetAsync<T>(assetName);
            _loadedAssets[key] = handle;

            try {
                await handle.ToUniTask();
            }
            catch (Exception e) {
                Debug.LogError($"[AddressableService] Exception loading asset '{assetName}' of type {typeof(T)}: {e.Message}");
                _loadedAssets.Remove(key);
                return default;
            }

            if (handle.Status == AsyncOperationStatus.Succeeded) {
                return handle.Result;
            }

            Debug.LogError($"[AddressableService] Failed to load asset '{assetName}' of type {typeof(T)}. Status: {handle.Status}");
            _loadedAssets.Remove(key);
            if (handle.IsValid())
                Addressables.Release(handle);

            return default;
        }
        
        public void ReleaseAsset(string assetName) {
            List<(string, Type)> keysToRemove = new();
            foreach (var key in _loadedAssets.Keys) {
                if (key.Item1 == assetName) {
                    keysToRemove.Add(key);
                }
            }

            foreach (var key in keysToRemove) {
                if (_loadedAssets.TryGetValue(key, out var handle)) {
                    if (handle.IsValid())
                        Addressables.Release(handle);

                    _loadedAssets.Remove(key);
                }
            }
        }
    }
}