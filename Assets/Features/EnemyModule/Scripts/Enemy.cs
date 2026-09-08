using UnityEngine;
using Zenject;

namespace Features.EnemyModule.Scripts {
    public class Enemy : MonoBehaviour, IPoolable {
        public void OnSpawned() {
            gameObject.SetActive(true);
        }

        public void OnDespawned() {
            gameObject.SetActive(false);
        }
    }
}