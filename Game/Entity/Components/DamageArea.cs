using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class DamageArea : Area2D
{
    [Export]
    public Godot.Collections.Array<OnHitEffect> OnHitEffects { get; private set; } = [];

    [Export]
    public int Damage { get; set; }

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
        if (body is BaseEntity entity)
        {
            foreach (var e in OnHitEffects)
                e.Apply(this, entity);

            entity.TakeDamage(Damage);
        }
    }
}
