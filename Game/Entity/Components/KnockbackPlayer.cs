using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class KnockbackPlayer : OnHitEffect
{
    [Export]
    public float KnockbackPower = 30.0f;

    public override void Apply(Node2D from, BaseEntity player)
    {
        var dir = from.GlobalPosition.DirectionTo(player.GlobalPosition);
        player.Velocity += dir * KnockbackPower;
    }
}
