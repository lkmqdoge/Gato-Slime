using System;
using Godot;

namespace GatoSlime.Game.Player;

public partial class ByTheWall : AtomicState
{
    public override void Enter()
    {
        base.Enter();
        Root.BlackBoard["velocity"] = Root.BlackBoard["direction"];
    }
}
