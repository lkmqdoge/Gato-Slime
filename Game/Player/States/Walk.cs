namespace GatoSlime.Game.Player;

public partial class Walk : AtomicState
{
    public override void Enter()
    {
        base.Enter();
        Root.BlackBoard["animation"] = "Walk";
    }
}
