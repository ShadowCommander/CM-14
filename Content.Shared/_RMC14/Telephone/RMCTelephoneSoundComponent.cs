using Robust.Shared.GameStates;

namespace Content.Shared._RMC14.Telephone;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(SharedRMCTelephoneSystem))]
public sealed partial class RMCTelephoneSoundComponent : Component
{
    [DataField, AutoNetworkedField]
    public EntityUid? Phone;
}
