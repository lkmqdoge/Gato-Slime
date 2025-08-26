using Godot;
using System;

namespace GatoSlime.Game.Player;

public partial class OnLadder : AtomicState
{
    [Export]
    private float _climbSpeed = 90.0f; 

    public override void Enter()
    {
        base.Enter();
        Root.BlackBoard["speed"] = (float)Root.BlackBoard["speed"] * 0.25f;
        Root.BlackBoard["acceleration"] = (float)Root.BlackBoard["acceleration"] * 0.25f;
        Root.BlackBoard["friction"] = (float)Root.BlackBoard["friction"] * 0.25f;
    }

    public override void UpdatePhysic(double delta)
    {
        base.UpdatePhysic(delta);

        var dir = (Vector2)Root.BlackBoard["direction"];
        var vel = (Vector2)Root.BlackBoard["velocity"];

        Root.BlackBoard["velocity"] = new Vector2(vel.X, dir.Y * _climbSpeed);
    }


}
