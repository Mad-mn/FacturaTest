using System;
using DG.Tweening;
using UnityEngine;

namespace Features.CarModule.Scripts {
    public class CarAnimationController : MonoBehaviour {
        [SerializeField] private Transform _view;
        
        [SerializeField] private float _takeDamagePunchScaleMultiplier = 1.5f;
        [SerializeField] private float _takeDamageAnimationDuration = 0.5f;
        
        private Vector3 _defaultScale;
        
        private void Start() {
            _defaultScale = _view.localScale;
        }
        
        public void PlayDamageAnimation(Action callback) {
            _view.DOPunchScale(Vector3.one * _takeDamagePunchScaleMultiplier, _takeDamageAnimationDuration, 1)
                .OnComplete(() => {
                                _view.localScale = _defaultScale;
                                callback?.Invoke();
                            });
        }
    }
}