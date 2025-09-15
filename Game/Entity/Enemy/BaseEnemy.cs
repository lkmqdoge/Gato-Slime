using GatoSlime.Entity;
using Godot;

namespace GatoSlime.Enemy;

[GlobalClass]
public abstract partial class BaseEnemy : BaseEntity
{
    protected Area2D _damageArea;

    public override void _Ready()
    {
        base._Ready();
        _damageArea = GetNode<Area2D>("%DamageArea");
    }
}
