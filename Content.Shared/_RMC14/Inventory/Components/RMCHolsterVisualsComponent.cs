using Content.Shared._RMC14.Inventory.EntitySystems;
using Robust.Shared.GameStates;

namespace Content.Shared._RMC14.Inventory.Components;

[RegisterComponent, NetworkedComponent]
[Access(typeof(RMCHolsterVisualsSystem))]
public sealed partial class RMCHolsterVisualsComponent : Component
{
    [DataField]
    public string? ContainerId;

    [DataField]
    public string? FilledLayerPrefix;
}
