using UnityEngine;

namespace Features.TurretModule.Scripts {
    public class TurretController : MonoBehaviour {
        [SerializeField] private Transform _view;
        
        public Transform View =>
            _view;
    }
}