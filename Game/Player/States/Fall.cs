using System;
using Godot;

namespace GatoSlime.Game.Player;

public partial class Fall : AtomicState
{
    [Export]
    private JumpCalc _jumpCalc;

    public override void Enter()
    {
        base.Enter();
        Root.BlackBoard["gravity"] = _jumpCalc.FallGravity;
    }
}
