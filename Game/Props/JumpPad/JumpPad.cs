using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game.Props;

public partial class JumpPad : Area2D
{
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
            player.Velocity -= new Vector2(0, GameConstants.JumpPadVelocity);
    }
}
