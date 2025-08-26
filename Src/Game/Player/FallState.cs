using Godot;

namespace GatoSlime.Game.Player;

public class FallState : PlayerState
{
    public override void UpdatePhysic(double delta)
    {
        Player.AccelerateX(delta);
        Player.Velocity += new Vector2(0, Player.FallGravity);
        Player.MoveAndSlide();
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.IsOnFloor())
        {
            if (Player.MoveDirection.X < 0.1f)
                StateMachine.SetState<IdleState>();
            else
                StateMachine.SetState<WalkState>();

            return;
        }

        if (Player.IsOnLadder() && Player.MoveDirection.Y > 0.1f)
        {
            StateMachine.SetState<LadderState>();
            return;
        }
    }
}