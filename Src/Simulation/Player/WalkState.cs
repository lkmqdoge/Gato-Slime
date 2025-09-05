using GatoSlime.Common;

namespace GatoSlime.Game.Player;

public class WalkState(Player player, PlayerStateMachine stateMachine) : PlayerState(player, stateMachine)
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
        if (!Player.IsMovingX())
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

        if (Player.IsOnLadder() && Player.IsMovingY())
        {
            StateMachine.SetState<LadderState>();
            return;
        }
    }
}
