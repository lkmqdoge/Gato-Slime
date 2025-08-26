using Godot;
using System;
namespace GatoSlime.Game.Player;

public partial class InAir : CompoundState
{
    [Export]
    public float Speed { get; private set; } = 400;

    [Export]
    public float Acceleration { get; private set; } = 350;

    [Export]
    public float Friction { get; private set; } = 1200;

    public override void Enter()
    {
        base.Enter();

        Root.BlackBoard["speed"] = Speed;
        Root.BlackBoard["acceleration"] = Acceleration;
        Root.BlackBoard["friction"] = Friction;
    }

    public override void UpdatePhysic(double delta)
    {
        base.UpdatePhysic(delta);

        var gravity = (float)Root.BlackBoard["gravity"];

        var velocity = (Vector2)Root.BlackBoard["velocity"];
        velocity.Y += (float)delta * gravity;
        Root.BlackBoard["velocity"] = velocity;
    }
}
