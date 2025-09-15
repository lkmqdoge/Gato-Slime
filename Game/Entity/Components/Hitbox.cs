using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class Hitbox : Area2D
{
    [Export]
    public BaseEntity Entity { get; private set; }
}
