using LKMQUtils;

namespace GatoSlime.Game.Player;

public abstract class PlayerState(Player player, PlayerStateMachine stateMachine) : IState
{
    public PlayerStateMachine StateMachine = stateMachine;
    public Player Player = player;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void UpdateLogic(double delta) { }

    public virtual void UpdatePhysic(double delta) { }
}
