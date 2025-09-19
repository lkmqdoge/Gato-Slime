using Godot;

namespace GatoSlime.Game.Props;

public partial class Ladder : Area2D
{
    public override void _Ready()
    {
        Connect(Area2D.SignalName.BodyEntered, Callable.From<Node>(OnBodyEntered));
        Connect(Area2D.SignalName.BodyExited, Callable.From<Node>(OnBodyExited));
    }

    private void OnBodyEntered(Node body)
    {
        if (body is Player.Player p)
        {
            p.LadderCount++;
            p.LastLadderPosition = GlobalPosition;
        }
    }

    private void OnBodyExited(Node body)
    {
        if (body is Player.Player p)
        {
            p.LadderCount--;
        }
    }
}
