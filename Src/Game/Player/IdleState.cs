namespace GatoSlime.Game.Player;

public class IdleState : PlayerState
{
    public override void UpdatePhysic(double delta)
    {
        Player.DecelerateX(delta);
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.MoveDirection.X > 0.1f)
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

        if (Player.IsOnLadder() && Player.MoveDirection.Y > 0.1f)
        {
            StateMachine.SetState<LadderState>();
            return;
        }
    }
}
