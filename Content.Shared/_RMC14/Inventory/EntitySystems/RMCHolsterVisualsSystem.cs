using Content.Shared._RMC14.Inventory.Components;
using Content.Shared.Clothing.EntitySystems;
using Content.Shared.Item;
using Content.Shared.Toilet.Components;
using Robust.Shared.Containers;
using Robust.Shared.Serialization;

namespace Content.Shared._RMC14.Inventory.EntitySystems;

public sealed class RMCHolsterVisualsSystem : EntitySystem
{
    [Dependency] private readonly SharedItemSystem _item = default!;
    [Dependency] private readonly SharedAppearanceSystem _appearance = default!;
    [Dependency] private readonly ClothingSystem _clothing = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<RMCHolsterVisualsComponent, ComponentInit>(OnComponentInit);
        SubscribeLocalEvent<RMCHolsterVisualsComponent, EntInsertedIntoContainerMessage>(OnContainerModified);
        SubscribeLocalEvent<RMCHolsterVisualsComponent, EntRemovedFromContainerMessage>(OnContainerModified);
    }

    private void OnComponentInit(Entity<RMCHolsterVisualsComponent> ent, ref ComponentInit args)
    {
        _appearance.SetData(ent, HolsterVisuals.Full, false);
    }

    private void OnContainerModified(Entity<RMCHolsterVisualsComponent> ent, ref EntInsertedIntoContainerMessage args)
    {
        if (ent.Comp.ContainerId != null && ent.Comp.ContainerId != args.Container.ID)
            return;

        SetVisuals(ent, ent.Comp.FilledLayerPrefix, ent.Comp.FilledLayerPrefix, true);
    }

    private void OnContainerModified(Entity<RMCHolsterVisualsComponent> ent, ref EntRemovedFromContainerMessage args)
    {
        if (ent.Comp.ContainerId != null && ent.Comp.ContainerId != args.Container.ID)
            return;
        if (args.Container.Count != 0)
            return;

        SetVisuals(ent, null, null, false);
    }

    private void SetVisuals(EntityUid uid, string? heldPrefix, string? equippedPrefix, bool full)
    {
        _item.SetHeldPrefix(uid, heldPrefix);
        _clothing.SetEquippedPrefix(uid, equippedPrefix);
        _appearance.SetData(uid, HolsterVisuals.Full, full);
    }
}

[Serializable, NetSerializable]
public enum HolsterVisuals : byte
{
    Full,
}
