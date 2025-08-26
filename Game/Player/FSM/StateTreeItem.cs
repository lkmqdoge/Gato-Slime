using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public abstract partial class StateTreeItem : Node
{
    public StateTree Root { get; set; }
}
