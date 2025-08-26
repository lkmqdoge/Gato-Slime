using System.Collections.Generic;
using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public partial class AtomicState : StateBase
{
    public override void Enter()
    {
        base.Enter();
        Root.InvokeLeaf(this);
    }

    public sealed override void HandleTransition(string to, HashSet<string> processed)
    {
        Parent?.HandleTransition(to, processed);
    }

    public sealed override void Leaf(IStateTreeVisitor visitor)
    {
        visitor.HandleAtomicState(this);
    }
}
