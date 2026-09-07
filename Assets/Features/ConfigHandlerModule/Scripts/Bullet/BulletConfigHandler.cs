using Features.AddressableModule.Scripts;

namespace Features.ConfigHandlerModule.Scripts.Bullet {
    public class BulletConfigHandler : ConfigHandler<BulletConfig> {
        public BulletConfigHandler(IAddressableService addressableService) : base(addressableService) { }
        
        protected override string ConfigName => AssetConstants.BULLET_CONFIG;
    }
}