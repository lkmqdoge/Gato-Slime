using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public partial class Mover : Node
{
    [Export]
    public Player Player { get; private set; }

    public Vector2 Velocity { get; set; }

    public Vector2 VelocityOverride { get; set; }

    public void Move()
    {
        if (VelocityOverride != Vector2.Zero)
        {
            Velocity = VelocityOverride;
            VelocityOverride = Vector2.Zero;
        }

        Player.Velocity = Velocity;
        Player.MoveAndSlide();
    }
}
