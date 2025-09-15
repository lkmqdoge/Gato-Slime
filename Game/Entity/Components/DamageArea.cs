using GatoSlime.Game.Player;
using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class DamageArea : Area2D
{
    [Export]
    public Godot.Collections.Array<OnHitEffect> OnHitEffects { get; private set; } = [];

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    public override void _ExitTree()
    {
        BodyEntered -= OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Player p)
            foreach (var e in OnHitEffects)
                e.Apply(this, p);
    }
}
