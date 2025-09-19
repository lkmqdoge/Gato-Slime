using Godot;

namespace GatoSlime.Game.Props;

public partial class SlimeFlood : Node2D
{
    [Export]
    public float Speed { get; set; } = 200.0f;


    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += new Vector2(0, Speed * (float)delta); 
    }
}
