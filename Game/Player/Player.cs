using System;
using GatoSlime.Game.Props;
using Godot;

namespace GatoSlime.Game.Player;

public partial class Player : CharacterBody2D
{
    public Mover Mover { get; private set; }

    public StateTree StateTree { get; private set; }

    private Area2D _interactArea;

    private Sprite2D _bodySprite;

    private AnimationTree _animationTree;

    private AnimationNodeStateMachinePlayback _playback;

    private Timer _jumpTimer;

    private Timer _coyoteTimer;

    private bool _jumped;

    private int _laddersCount;

    private Vector2 _direction;

    public override void _Ready()
    {
        Mover = GetNode<Mover>("Mover");
        StateTree = GetNode<StateTree>("StateTree");

        _bodySprite = GetNode<Sprite2D>("%BodySprite");
        _interactArea = GetNode<Area2D>("InteractArea");
        _animationTree = GetNode<AnimationTree>("%AnimationTree");
        _jumpTimer = GetNode<Timer>("JumpTimer");

        _playback = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");

        _interactArea.AreaEntered += OnInteractEntered;
        _interactArea.AreaExited += OnInteractExited;

        _jumpTimer.Timeout += OnJumpTimeOut;
    }

    public override void _ExitTree()
    {
        _interactArea.AreaEntered -= OnInteractEntered;
        _interactArea.AreaExited -= OnInteractExited;
        _jumpTimer.Timeout -= OnJumpTimeOut;
    }

    public override void _PhysicsProcess(double delta)
    {
        _direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

        StateTree.BlackBoard["direction"] = _direction;
        StateTree.PushEvent(_direction.X == 0.0f ? "MoveStop" : "MoveStart");
        StateTree.PushEvent(IsOnFloor() ? "OnFloor" : "NotOnFloor");
        StateTree.PushEvent(IsOnWall() ? "OnWall" : "NotOnWall");
        StateTree.PushEvent(IsOnCeiling() ? "CeilingEnter" : "CeilingExit");

        if (_direction.Y != 0.0f && _laddersCount > 0)
            StateTree.PushEvent("LadderEnter");

        if (_direction != Vector2.Zero)
            _bodySprite.FlipH = _direction.X < 0;

        var animation = (string)StateTree.BlackBoard["animation"];
        _playback.Travel(animation);

        if (_jumped)
            StateTree.PushEvent("Jump");

        Mover.Velocity = (Vector2)StateTree.BlackBoard["velocity"];
        Mover.Move();
        StateTree.BlackBoard["velocity"] = Mover.Velocity;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("jump"))
        {
            _jumpTimer.Start();
            _jumped = true;
        }

        if (@event.IsActionReleased("jump"))
        {
            StateTree.PushEvent("JumpEnded");
            _jumped = false;
        }
    }

    private void OnInteractEntered(Area2D area)
    {
        if (area is Ladder)
        {
            _laddersCount++;
        }
    }

    private void OnInteractExited(Area2D area)
    {
        if (area is Ladder)
        {
            _laddersCount--;
            if (_laddersCount == 0)
                StateTree.PushEvent("LadderExit");
        }
    }

    private void OnJumpTimeOut()
    {
        _jumped = false;
    }
}
