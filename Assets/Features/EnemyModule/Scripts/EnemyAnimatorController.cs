using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Features.EnemyModule.Scripts {
    public class EnemyAnimatorController : MonoBehaviour {
        private static readonly int Run = Animator.StringToHash("Run");

        [SerializeField] private Animator _animator;
        [SerializeField] private float _takeDamagePunchScaleMultiplier = 1.5f;
        [SerializeField] private float _takeDamageAnimationDuration = 0.5f;
        [SerializeField] private Transform _view;

        public void StartRun() {
            _animator.SetBool(Run, true);
        }

        public void StopRun() {
            _animator.SetBool(Run, false);
        }

        public void PlayDamageAnimation(Action callback) {
            _view.DOPunchScale(Vector3.one * _takeDamagePunchScaleMultiplier, _takeDamageAnimationDuration, 1)
                .OnComplete(() => callback?.Invoke());
        }
    }
}