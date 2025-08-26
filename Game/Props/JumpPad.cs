using Godot;

namespace GatoSlime.Game.Props;

public partial class JumpPad : Area2D
{
    [Export]
    private float _jumpVelocity = 80.0f;

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
        if (body is Player.Player player)
            player.Mover.VelocityOverride = new Vector2(
                player.Mover.Velocity.X,
                _jumpVelocity * -1.0f
            );
    }
}
