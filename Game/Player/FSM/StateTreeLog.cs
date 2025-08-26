using System.Text;
using Godot;

namespace GatoSlime.Game.Player;

public class StateTreeLog : IStateTreeVisitor
{
    private readonly StringBuilder _sbPath = new();

    public void HandleAtomicState(StateBase state)
    {
        _sbPath.AppendFormat("/{0} ", state.Name);
        GD.Print(_sbPath.ToString());
    }

    public void HandleCompoundState(CompoundState state) =>
        _sbPath.AppendFormat("/{0}", state.Name);
}
