using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game.Player;

public class LadderState(Player player, PlayerStateMachine stateMachine)
    : PlayerState(player, stateMachine)
{
    public override void Enter()
    {
        Player.GlobalPosition = Player.LastLadderPosition;
    }

    public override void UpdatePhysic(double delta)
    {
        Player.Velocity = new Vector2(
            0,
            GameConstants.PlayerLadderSpeed * Player.MoveDirection.Y * (float)delta
        );
        Player.MoveAndSlide();
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
