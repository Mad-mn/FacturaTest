using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Features.ConfigHandlerModule.Scripts {
    public interface IConfigHandler<TConfig> where TConfig : ScriptableObject {
        UniTask Initialize();
        public TConfig Config { get; }
    }
}