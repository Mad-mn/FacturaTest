using System;
using DG.Tweening;
using Features.CameraModule.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.HealthModule.Scripts {
    public class HealthBar : MonoBehaviour {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _fill;
        [SerializeField] private Image _fakeFill;
        [SerializeField] private float _fakeFillAnimationDuration = 0.2f;
        [SerializeField] private float _fakeFillAnimationDelay = 0.2f;
        [SerializeField] private bool _hideIfFull;
        [SerializeField] private bool _lookAtCameraInUpdate;

        private Camera _camera;
        private float _maxHealth;
        private float _currentHealth;

        [Inject]
        private void InjectDependencies(ICameraService cameraService) {
            _camera = cameraService.Camera;
            _canvas.worldCamera = cameraService.Camera;
        }

        public void Setup(float max) {
            _maxHealth = max;
            UpdateHealth(max);
        }

        public void UpdateHealth(float current) {
            _currentHealth = current;
            _fill.fillAmount = (_currentHealth / _maxHealth);
            if (_currentHealth < _maxHealth)
                _fakeFill.DOFillAmount(_currentHealth / _maxHealth, _fakeFillAnimationDuration)
                    .SetDelay(_fakeFillAnimationDelay);

            if (_hideIfFull)
                _canvas.gameObject.SetActive(_fill.fillAmount < 1);
        }

        private void LateUpdate() {
            if (_lookAtCameraInUpdate)
                transform.forward = transform.position - _camera.transform.position;
        }
    }
}