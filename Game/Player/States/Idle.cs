namespace GatoSlime.Game.Player;

public partial class Idle : AtomicState
{
    public override void Enter()
    {
        base.Enter();

        Root.BlackBoard["animation"] = "Idle";
    }
}
