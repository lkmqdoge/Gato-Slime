using Godot;

namespace GatoSlime.Entity;

public abstract partial class BaseEntity : CharacterBody2D
{
    public Hitbox Hitbox { get; private set; }
    public Health Health { get; private set; }

    public abstract void Die();

    public virtual void TakeDamage(int amount) => Health.TakeDamage(amount);

    public override void _Ready()
    {
        Hitbox = GetNode<Hitbox>("%Hitbox");
        Health = GetNode<Health>("%Health");
    }
}
