using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public abstract partial class Transition : StateTreeItem
{
    [Export]
    public StateBase To { get; private set; }

    public abstract bool CheckCondition();
}
