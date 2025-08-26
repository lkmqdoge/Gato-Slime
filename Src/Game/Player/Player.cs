using GatoSlime.Common;
using GatoSlime.Game.Props;
using Godot;

namespace GatoSlime.Game.Player;

public partial class Player : CharacterBody2D
{
    public PlayerStateMachine StateMachine { get; private set; }
    public float Speed { get; set; }
    public float Acceleration { get; set; }
    public float Deceleration { get; set; }

    public Vector2 MoveDirection { get; private set; }
    public float JumpGravity { get; private set; }
    public float FallGravity { get; private set; }
    public float JumpVelocity { get; private set; }

    public float JumpTimeToPeak { get; private set; }
    public float JumpTimeToDescent { get; private set; }
    public float JumpHeight { get; private set; }

    public Vector2 LastLadderPosition { get; private set; }

    private int _laddersCount;

    private Area2D _interactArea;
    private Vector2 _direction;
    private Timer _jumpBufferTimer;
    private Timer _coyoteTimer;

    public override void _Ready()
    {
        JumpTimeToPeak = GameConstants.PlayerJumpTimeToPeak;
        JumpTimeToDescent = GameConstants.PlayerJumpTimeToDescent;
        JumpHeight = GameConstants.PlayerJumpHeight;
        UpdateGravity();

        _jumpBufferTimer = GetNode<Timer>("%JumpBufferTimer");
        _coyoteTimer = GetNode<Timer>("%CoyoteTimer");
        _interactArea = GetNode<Area2D>("%InteractArea");

        _interactArea.AreaEntered += OnInteractAreaEntered;
        _interactArea.AreaExited += OnInteractAreaExited;

        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(new IdleState());
        StateMachine.AddState(new WalkState());
        StateMachine.AddState(new JumpState());
        StateMachine.AddState(new LadderState());
        StateMachine.AddState(new IdleState());

        StateMachine.SetState<IdleState>();
    }

    public override void _PhysicsProcess(double delta)
    {
        ReadInput();
        StateMachine.UpdatePhysic(delta);
    }

    public override void _Process(double delta)
    {
        StateMachine.UpdateLogic(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.Jump))
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

    public void BufferJump()
    {
        _jumpBufferTimer.Start(GameConstants.PlayerJumpBufferTime);
    }

    public bool IsJumpBuffered()
    {
        return _jumpBufferTimer.TimeLeft > 0;
    }

    public void CancelJump()
    {
        // Velocity = new Vector2(Velocity.X, 0.0f);
    }

    public bool IsOnLadder()
    {
        return _laddersCount > 0;
    }

    public void ReadInput()
    {
        MoveDirection = Input.GetVector(
            GameConstants.MoveLeft,
            GameConstants.MoveRight,
            GameConstants.MoveUp,
            GameConstants.MoveDown
        );
    }

    public void AccelerateX(double delta)
    {
        Velocity = new Vector2(
            (float)Mathf.MoveToward(Velocity.X, MoveDirection.X * Speed, Acceleration * delta),
            Velocity.Y
        );
    }

    public void DecelerateX(double delta)
    {
        Velocity = new Vector2(
            (float)Mathf.MoveToward(Velocity.X, 0, Deceleration * delta),
            Velocity.Y
        );
    }

    private void OnInteractAreaEntered(Area2D area)
    {
        if (area is Ladder ladder)
        {
            _laddersCount++;
            LastLadderPosition = ladder.GlobalPosition;
        }
    }

    private void OnInteractAreaExited(Area2D area)
    {
        if (area is Ladder)
            _laddersCount--;
    }
}
