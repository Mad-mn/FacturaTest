using Features.ConfigHandlerModule.Scripts;
using Features.EnemyModule.Scripts.Configs;
using Features.EnemyModule.Scripts.Pools;
using Features.PoolModule.Scripts;
using Zenject;

namespace Features.EnemyModule.Scripts.Installers {
    public class EnemyModuleInstaller : Installer<EnemyModuleInstaller> {
        public override void InstallBindings() {
            Container.Bind<IPool<Enemy>>()
                .To<EnemyPool<Enemy>>()
                .AsSingle();

            Container.Bind<IEnemyService>()
                .To<EnemyService>()
                .AsSingle();

            Container.Bind<IConfigHandler<EnemySpawnConfig>>()
                .To<EnemySpawnConfigHandler<EnemySpawnConfig>>()
                .AsSingle();
            
            Container.Bind<IEnemySpawner>()
                .To<EnemySpawner>()
                .AsSingle();

            Container.Bind<IConfigHandler<EnemyConfig>>()
                .To<EnemyConfigHandler<EnemyConfig>>()
                .AsSingle();
        }
    }
}