using Godot;

namespace GatoSlime.Game.Player;

public class JumpState(Player player, PlayerStateMachine stateMachine)
    : PlayerState(player, stateMachine)
{
    public override void Enter()
    {
        Player.Jump();

        if (Player.JumpsLeft < 1)
            Player.PlayAnimation("Jump");
    }

    public override void UpdatePhysic(double delta)
    {
        Player.AccelerateX(delta);
        Player.Velocity += new Vector2(0, Player.JumpGravity * (float)delta);
        Player.MoveAndSlide();
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.Velocity.Y > 0 || Player.IsOnCeiling() || Player.IsOnFloor())
        {
            StateMachine.SetState<FallState>();
            return;
        }

        if (Player.IsOnLadder() && Player.IsMovingY())
        {
            StateMachine.SetState<LadderState>();
            return;
        }
    }
}
