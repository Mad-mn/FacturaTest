using Features.AddressableModule.Scripts;
using Features.ConfigHandlerModule.Scripts;

namespace Features.TurretModule.Scripts.Configs {
    public class TurretConfigHandler : ConfigHandler<TurretConfig> {
        public TurretConfigHandler(IAddressableService addressableService) : base(addressableService) { }
        
        protected override string ConfigName => AssetConstants.TURRET_CONFIG;
    }
}