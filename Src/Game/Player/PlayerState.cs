using LKMQUtils;

namespace GatoSlime.Game.Player;

public abstract class PlayerState : IState
{
    public PlayerStateMachine StateMachine;
    public Player Player;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void UpdateLogic(double delta) { }

    public virtual void UpdatePhysic(double delta) { }
}
