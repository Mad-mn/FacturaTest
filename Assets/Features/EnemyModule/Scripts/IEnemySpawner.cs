using System.Collections.Generic;

namespace Features.EnemyModule.Scripts {
    public interface IEnemySpawner {
        void Spawn();
        void Respawn();
        IReadOnlyList<Enemy> Enemies { get; }
    }
}