using GatoSlime.Game.Player;
using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public abstract partial class OnHitEffect : Resource
{
    public abstract void Apply(Node2D from, Player player);
}
