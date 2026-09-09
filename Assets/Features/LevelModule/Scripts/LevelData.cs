using System;
using UnityEngine;

namespace Features.LevelModule.Scripts {
    [CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData")]
    public class LevelData : ScriptableObject {
        [field: SerializeField] public float SideMovingFrequency { get; private set; }
        [field: SerializeField] public float CarSpeed { get; private set; }
        [field: SerializeField] public float MovingDistance { get; private set; }
        [field: SerializeField] public float RoadWidth { get; private set; }
        [field: SerializeField] public float CarHealth { get; private set; }
    }
}