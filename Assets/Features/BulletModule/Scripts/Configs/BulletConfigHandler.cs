using Features.AddressableModule.Scripts;
using Features.ConfigHandlerModule.Scripts;

namespace Features.BulletModule.Scripts.Configs {
    public class BulletConfigHandler : ConfigHandler<BulletConfig> {
        public BulletConfigHandler(IAddressableService addressableService) : base(addressableService) { }
        
        protected override string ConfigName => AssetConstants.BULLET_CONFIG;
    }
}