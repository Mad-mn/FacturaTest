using Features.AddressableModule.Scripts;

namespace Features.ConfigHandlerModule.Scripts.Turret {
    public class TurretConfigHandler : ConfigHandler<TurretConfig> {
        public TurretConfigHandler(IAddressableService addressableService) : base(addressableService) { }
        
        protected override string ConfigName => AssetConstants.TURRET_CONFIG;
    }
}