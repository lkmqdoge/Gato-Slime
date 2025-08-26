using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public partial class EventTransition : Transition
{
    [Export]
    private string _event;

    public override bool CheckCondition() => Root.HasEvent(_event);
}
