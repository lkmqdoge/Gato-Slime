namespace GatoSlime.Common;

public static class GameConstants
{
    // Input map
    public const string MoveLeft = "move_left";
    public const string MoveRight = "move_right";
    public const string MoveUp = "move_up";
    public const string MoveDown = "move_down";
    public const string Jump = "jump";

    // Player physic
    public const float PlayerWalkSpeed = 400.0f;
    public const float PlayerWalkAcceleration = 350.0f;
    public const float PlayerWalkDeceleration = 800.0f;

    // Jump
    public const float PlayerJumpHeight = 80.0f;
    public const float PlayerJumpTimeToPeak = 0.5f;
    public const float PlayerJumpTimeToDescent = 0.4f;

    // Timers
    public const float PlayerCoyoteTime = 0.1f;
    public const float PlayerJumpBufferTime = 0.1f;

    // Ladder
    public const float PlayerLadderSpeed = 50.0f;
}
