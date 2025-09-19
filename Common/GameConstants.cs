namespace GatoSlime.Common;

public static class GameConstants
{
    // Input map
    public const string MoveLeft = "move_left";
    public const string MoveRight = "move_right";
    public const string MoveUp = "move_up";
    public const string MoveDown = "move_down";
    public const string Jump = "jump";

    public const string Pause = "pause";
    public const string DebugReload = "_debug_reload";
    public const string DebugShowCollisions = "_debug_show_collisions";

    // Player physic
    public const float PlayerWalkSpeed = 120.0f;
    public const float PlayerWalkAcceleration = 500.0f;
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

    public static class UIDS
    {
        public const string PauseMenu = "uid://bpxb6a4jyjhyq";
        public const string OptionsMenu = "";
        public const string MainMenu = "uid://cff7jokir16xc";

        public const string Stage = "uid://dsogacyl3drsd";
        public const string Debug001 = "uid://b1erno3wa1kvu";
        public const string Player = "uid://byagbfrpk8sgs";

        public const string DeathEffect_01 = "uid://brk8353l7l45q";
    }
}
