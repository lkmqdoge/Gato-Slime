using Godot;

namespace GatoSlime.Game.Player;

public class FallState(Player player, PlayerStateMachine stateMachine)
    : PlayerState(player, stateMachine)
{
    public override void UpdatePhysic(double delta)
    {
        if (Player.JumpsLeft == 2)
            Player.JumpsLeft = 1;
    
        Player.AccelerateX(delta);
        Player.Velocity += new Vector2(0, Player.FallGravity * (float)delta);
        Player.MoveAndSlide();
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.IsOnFloor())
        {
            if (Player.IsMovingX())
                StateMachine.SetState<IdleState>();
            else
                StateMachine.SetState<WalkState>();

            return;
        }

        if (Player.IsOnLadder() && Player.IsMovingY())
        {
            StateMachine.SetState<LadderState>();
            return;
        }
        if (Player.IsJumpBuffered())
        {
            StateMachine.SetState<JumpState>();
            return;
        }
    }
}
