using System.Threading;
using Cysharp.Threading.Tasks;

namespace Features.SceneLoaderModule.Scripts {
    public interface ISceneLoader {
        UniTask LoadSceneAsync(SceneType sceneType, CancellationToken cancellationToken);
    }
}