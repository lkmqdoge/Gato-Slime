using System;
using Godot;

namespace GatoSlime.Game.Player;

public partial class WallGrip : AtomicState
{
    public override void UpdatePhysic(double delta)
    {
        base.UpdatePhysic(delta);

        var dir = (Vector2)Root.BlackBoard["direction"];
        var vel = (Vector2)Root.BlackBoard["velocity"];

        Root.BlackBoard["velocity"] = new Vector2(vel.X, dir.Y * 20.0f);
    }
}
