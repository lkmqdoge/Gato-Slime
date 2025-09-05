namespace GatoSlime.Game.Player;

public class IdleState(Player player, PlayerStateMachine stateMachine) : PlayerState(player, stateMachine)
{
    public override void Enter()
    {
        Player.PlayAnimation("Idle");
        Player.JumpsLeft = Player.MaxJumps;
    }

    public override void UpdatePhysic(double delta)
    {
        Player.DecelerateX(delta);
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.IsMovingX())
        {
            StateMachine.SetState<WalkState>();
            return;
        }

        if (!Player.IsOnFloor())
        {
            StateMachine.SetState<FallState>();
            return;
        }

        if (Player.IsJumpBuffered())
        {
            StateMachine.SetState<JumpState>();
            return;
        }

        if (Player.IsOnLadder() && Player.IsMovingY())
        {
            StateMachine.SetState<LadderState>();
            return;
        }
    }
}
