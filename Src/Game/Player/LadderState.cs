using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game.Player;

public class LadderState : PlayerState
{
    public override void Enter()
    {
        Player.GlobalPosition = Player.LastLadderPosition;
    }

    public override void UpdatePhysic(double delta)
    {
        Player.Velocity = new Vector2(0, GameConstants.PlayerLadderSpeed * Player.MoveDirection.Y);
    }

    public override void UpdateLogic(double delta)
    {
        if (!Player.IsOnLadder() || Player.MoveDirection.X > 0.1f)
        {
            StateMachine.SetState<FallState>();
            return;
        }
    }
}
