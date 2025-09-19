using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game.Player;

public class LadderState(Player player, PlayerStateMachine stateMachine)
    : PlayerState(player, stateMachine)
{
    public override void Enter()
    {
        Player.JumpsLeft = Player.MaxJumps;
    }

    public override void UpdatePhysic(double delta)
    {
        var dX = Player.LastLadderPosition.X - Player.GlobalPosition.X;
        Player.Velocity = new Vector2(
            dX * 3,
            GameConstants.PlayerLadderSpeed * Player.MoveDirection.Y * (float)delta
        );
        Player.MoveAndSlide();

        if (Player.IsOnFloor())
            Player.GoDown();
    }

    public override void UpdateLogic(double delta)
    {
        if (!Player.IsOnLadder() || Player.IsMovingX())
        {
            StateMachine.SetState<FallState>();
            return;
        }
    }
}
