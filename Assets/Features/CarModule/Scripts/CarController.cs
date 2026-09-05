using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarController : MonoBehaviour {
        [SerializeField] private Transform _view;
        
        public Transform View => _view;
    }
}