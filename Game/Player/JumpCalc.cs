using System;
using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public partial class JumpCalc : Node
{
    public event Action Updated;

    [Export]
    public float TimeToPeak
    {
        get => _timeToPeak;
        set
        {
            _timeToPeak = value;
            Update();
        }
    }

    [Export]
    public float TimeToDescent
    {
        get => _timeToDescent;
        set
        {
            _timeToDescent = value;
            Update();
        }
    }

    [Export]
    public float Height
    {
        get => _height;
        set
        {
            _height = value;
            Update();
        }
    }

    public float JumpGravity { get; private set; }

    public float FallGravity { get; private set; }

    public float JumpVelocity { get; private set; }

    private float _timeToPeak;

    private float _timeToDescent;

    private float _height;

    private void Update()
    {
        JumpVelocity = 2.0f * Height / TimeToPeak * -1.0f;
        JumpGravity = 2.0f * Height / (TimeToPeak * TimeToPeak);
        FallGravity = 2.0f * Height / (TimeToDescent * TimeToDescent);
    }

    public override void _Ready()
    {
        Update();
    }
}
