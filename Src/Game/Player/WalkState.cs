using GatoSlime.Common;

namespace GatoSlime.Game.Player;

public class WalkState : PlayerState
{
    public override void Enter()
    {
        Player.Speed = GameConstants.PlayerWalkSpeed;
        Player.Acceleration = GameConstants.PlayerWalkAcceleration;
        Player.Deceleration = GameConstants.PlayerWalkDeceleration;
    }

    public override void UpdatePhysic(double delta)
    {
        Player.AccelerateX(delta);
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.MoveDirection.X < 0.1f)
        {
            StateMachine.SetState<IdleState>();
            return;
        }

        if (Player.IsJumpBuffered())
        {
            StateMachine.SetState<JumpState>();
            return;
        }

        if (Player.Velocity.Y > 0)
        {
            StateMachine.SetState<FallState>();
            return;
        }

        if (Player.IsOnLadder() && Player.MoveDirection.Y > 0.1f)
        {
            StateMachine.SetState<LadderState>();
            return;
        }
    }
}
