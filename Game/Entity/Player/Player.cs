using System;
using GatoSlime.Common;
using GatoSlime.Entity;
using GatoSlime.Game.Props;
using Godot;
using LKMQUtils;

namespace GatoSlime.Game.Player;

public partial class Player : BaseEntity
{
    public float Speed { get; set; }
    public float Acceleration { get; set; }
    public float Deceleration { get; set; }
    public int LadderCount { get; set; }
    public Vector2 LastLadderPosition { get; set; }

    public PlayerStateMachine StateMachine { get; private set; }
    public Vector2 MoveDirection { get; private set; }
    public Vector2 LastMoveDirection { get; private set; }
    public float JumpGravity { get; private set; }
    public float FallGravity { get; private set; }
    public float JumpVelocity { get; private set; }

    public float JumpTimeToPeak { get; private set; }
    public float JumpTimeToDescent { get; private set; }
    public float JumpHeight { get; private set; }

    public int JumpsLeft { get; set; }
    public int MaxJumps { get; set; } = 2;

    private Area2D _hitbox;
    private Node2D _view;
    private Vector2 _direction;
    private Timer _jumpBufferTimer;
    private Timer _coyoteTimer;
    private AnimationNodeStateMachinePlayback _playback;

    public override void _Ready()
    {
        base._Ready();
        JumpTimeToPeak = GameConstants.PlayerJumpTimeToPeak;
        JumpTimeToDescent = GameConstants.PlayerJumpTimeToDescent;
        JumpHeight = GameConstants.PlayerJumpHeight;
        UpdateGravity();

        _jumpBufferTimer = GetNode<Timer>("%JumpBufferTimer");
        _coyoteTimer = GetNode<Timer>("%CoyoteTimer");
        _hitbox = GetNode<Area2D>("%Hitbox");
        _view = GetNode<Node2D>("%View");
        _playback = (AnimationNodeStateMachinePlayback)
            GetNode<AnimationTree>("%AnimationTree").Get("parameters/playback");

        _hitbox.Connect(Area2D.SignalName.BodyEntered, Callable.From<Node>(OnHitboxBodyEntered));
        _hitbox.Connect(Area2D.SignalName.BodyExited, Callable.From<Node>(OnHitboxBodyExited));

        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(new IdleState(this, StateMachine));
        StateMachine.AddState(new WalkState(this, StateMachine));
        StateMachine.AddState(new JumpState(this, StateMachine));
        StateMachine.AddState(new FallState(this, StateMachine));
        StateMachine.AddState(new LadderState(this, StateMachine));

        StateMachine.SetState<IdleState>();
    }

    public override void _PhysicsProcess(double delta)
    {
        ReadInput();
        StateMachine.UpdatePhysic(delta);
        FlipView();
    }

    public override void _Process(double delta)
    {
        StateMachine.UpdateLogic(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.Jump))
            if (Input.IsActionPressed(GameConstants.MoveDown) && IsOnFloor())
                GoDown();
            else
                BufferJump();

        if (@event.IsActionReleased(GameConstants.Jump))
            CancelJump();
    }

    public void UpdateGravity()
    {
        JumpVelocity = 2.0f * JumpHeight / JumpTimeToPeak * -1.0f;
        JumpGravity = 2.0f * JumpHeight / (JumpTimeToPeak * JumpTimeToPeak);
        FallGravity = 2.0f * JumpHeight / (JumpTimeToDescent * JumpTimeToDescent);
    }

    public bool IsMovingX() => Math.Abs(MoveDirection.X) > 0.1f;

    public bool IsMovingY() => Math.Abs(MoveDirection.Y) > 0.1f;

    public void BufferJump()
    {
        _jumpBufferTimer.Start(GameConstants.PlayerJumpBufferTime);
    }

    public bool IsJumpBuffered()
    {
        return _jumpBufferTimer.TimeLeft > 0 && JumpsLeft > 0;
    }

    public void Jump()
    {
        _jumpBufferTimer.Stop();
        JumpsLeft--;
        Velocity = new Vector2(Velocity.X, JumpVelocity);
        MoveAndSlide();
    }

    public void GoDown()
    {
        GlobalPosition += Vector2.Down;
    }

    public void CancelJump()
    {
        if (Velocity.Y < 0)
            Velocity = new Vector2(Velocity.X, JumpVelocity / 4);
    }

    public void StartCoyote()
    {
        if (_coyoteTimer.TimeLeft == 0)
            _coyoteTimer.Start(GameConstants.PlayerCoyoteTime);
    }

    public bool IsCoyoteEnded()
    {
        return _coyoteTimer.TimeLeft == 0;
    }

    public bool IsOnLadder()
    {
        return LadderCount > 0;
    }

    public void ReadInput()
    {
        MoveDirection = Input.GetVector(
            GameConstants.MoveLeft,
            GameConstants.MoveRight,
            GameConstants.MoveUp,
            GameConstants.MoveDown
        );

        if (MoveDirection != Vector2.Zero)
            LastMoveDirection = MoveDirection;
    }

    public void AccelerateX(double delta)
    {
        Velocity = new Vector2(
            (float)Mathf.MoveToward(Velocity.X, MoveDirection.X * Speed, Acceleration * delta),
            Velocity.Y
        );
        MoveAndSlide();
    }

    public void DecelerateX(double delta)
    {
        Velocity = new Vector2(
            (float)Mathf.MoveToward(Velocity.X, 0, Deceleration * delta),
            Velocity.Y
        );
        MoveAndSlide();
    }

    public void PlayAnimation(string name)
    {
        _playback.Travel(name);
    }

    private void OnHitboxBodyExited(Node body) { }

    private void OnHitboxBodyEntered(Node body) { }

    private void FlipView()
    {
        _view.Scale = new Vector2(LastMoveDirection.X > 0 ? 1 : -1, 1);
    }

    public override void Die()
    {
        Logger.Debug("Player fucking dies");
    }
}
