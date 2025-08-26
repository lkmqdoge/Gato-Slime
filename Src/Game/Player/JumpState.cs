using Godot;

namespace GatoSlime.Game.Player;

public class JumpState : PlayerState
{
    public override void Enter()
    {
        Player.Velocity = new Vector2(Player.Velocity.X, Player.JumpVelocity);
        Player.MoveAndSlide();
    }

    public override void UpdatePhysic(double delta)
    {
        Player.AccelerateX(delta);
        Player.Velocity += new Vector2(0, Player.JumpGravity);
        Player.MoveAndSlide();
    }

    public override void UpdateLogic(double delta)
    {
        if (Player.Velocity.Y > 0 || Player.IsOnCeiling())
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