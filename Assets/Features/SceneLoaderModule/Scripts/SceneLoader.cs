using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.SceneLoaderModule.Scripts {
    public class SceneLoader : ISceneLoader {

        private string _currentSceneName;
        public async UniTask LoadSceneAsync(SceneType sceneType, CancellationToken cancellationToken = default) {
            if (CheckForCurrentScene(sceneType.ToString())) {
                return;
            }
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneType.ToString());
            if (loadOperation == null) {
                Debug.LogError($"[SceneLoadService] Failed to load scene: {sceneType}");
                return;
            }

            loadOperation.allowSceneActivation = true;

            try {
                while (!loadOperation.isDone) {
                    if (cancellationToken.IsCancellationRequested) {
                        return;
                    }

                    await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
                }
            }
            catch (OperationCanceledException) {
                Debug.LogError($"[SceneLoadService] Failed to load scene: {sceneType}");
                return;
            }
            
            _currentSceneName = sceneType.ToString();
        }

        private bool CheckForCurrentScene(string sceneName) {
            return _currentSceneName == sceneName;
        }
    }
}