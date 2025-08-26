using System;
using Godot;

namespace GatoSlime.Game.Player;

public partial class Grounded : CompoundState
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

        Root.BlackBoard["velocity"] = (Vector2)Root.BlackBoard["velocity"] * Vector2.Right;
        Root.BlackBoard["speed"] = Speed;
        Root.BlackBoard["acceleration"] = Acceleration;
        Root.BlackBoard["friction"] = Friction;
    }
}
