﻿using Content.Shared.Access;
using Content.Shared.Alert;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared._RMC14.Marines.Squads;

[RegisterComponent, NetworkedComponent]
[Access(typeof(SquadSystem))]
[EntityCategory("Squads")]
public sealed partial class SquadTeamComponent : Component
{
    [DataField(required: true)]
    public Color Color;

    [DataField(required: true)]
    public SpriteSpecifier Background;

    [DataField]
    public ProtoId<AccessLevelPrototype>[] AccessLevels = Array.Empty<ProtoId<AccessLevelPrototype>>();

    [DataField]
    public HashSet<EntityUid> Members = new();

    [DataField]
    public Dictionary<ProtoId<AlertPrototype>, List<NetEntity>> Trackers = [];
}
