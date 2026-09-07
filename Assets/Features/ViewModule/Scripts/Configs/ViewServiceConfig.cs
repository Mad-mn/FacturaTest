using System.Collections.Generic;
using UnityEngine;

namespace Features.ViewModule.Scripts.Configs {
    [CreateAssetMenu(fileName = "ViewServiceConfig", menuName = "ViewSystem/ViewServiceConfig")]
    public class ViewServiceConfig : ScriptableObject {
        [SerializeField] private List<ViewConfigData> _viewConfigs;
        
        public IReadOnlyList<ViewConfigData> ViewConfigs => _viewConfigs;
    }
}