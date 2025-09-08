namespace GatoSlime.Common;

public static class GameConstants
{
    // Input map
    public const string MoveLeft = "move_left";
    public const string MoveRight = "move_right";
    public const string MoveUp = "move_up";
    public const string MoveDown = "move_down";
    public const string Jump = "jump";

    public const string DebugReload = "debug_reload";

    // Player physic
    public const float PlayerWalkSpeed = 200.0f;
    public const float PlayerWalkAcceleration = 185.0f;
    public const float PlayerWalkDeceleration = 600.0f;

    // Jump
    public const float PlayerJumpHeight = 32.0f;
    public const float PlayerJumpTimeToPeak = 0.44f;
    public const float PlayerJumpTimeToDescent = 0.32f;

    // Timers
    public const float PlayerCoyoteTime = 0.5f;
    public const float PlayerJumpBufferTime = 0.1f;

    // Ladder
    public const float PlayerLadderSpeed = 9500.0f;

    public const float JumpPadVelocity = 250.0f;
}
