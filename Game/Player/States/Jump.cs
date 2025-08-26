using System;
using Godot;

namespace GatoSlime.Game.Player;

public partial class Jump : AtomicState
{
    [Export]
    private JumpCalc _jumpCalc;

    public override void Enter()
    {
        base.Enter();

        Root.BlackBoard["gravity"] = _jumpCalc.JumpGravity;
        var velocity = (Vector2)Root.BlackBoard["velocity"];
        velocity.Y = _jumpCalc.JumpVelocity;
        Root.BlackBoard["velocity"] = velocity;
    }

    public override void UpdatePhysic(double delta)
    {
        if (((Vector2)Root.BlackBoard["velocity"]).Y > 0)
            Root.PushEvent("JumpEnded");
    }
}
