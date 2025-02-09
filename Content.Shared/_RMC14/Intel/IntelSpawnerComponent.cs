﻿using Robust.Shared.GameStates;

namespace Content.Shared._RMC14.Intel;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(IntelSystem))]
public sealed partial class IntelSpawnerComponent : Component
{
    [DataField, AutoNetworkedField]
    public IntelSpawnerType IntelType;
}
