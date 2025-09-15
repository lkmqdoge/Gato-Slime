using Godot;

namespace GatoSlime.Entity;

public abstract partial class BaseEntity : CharacterBody2D
{
    public Hitbox Hitbox { get; private set; }

    public abstract void Die();

    public abstract void TakeDamage(int amount);

    public override void _Ready()
    {
        base._Ready();
        Hitbox = GetNode<Hitbox>("%Hitbox");
    }
}
