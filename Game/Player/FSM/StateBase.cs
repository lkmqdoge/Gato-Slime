using System.Collections.Generic;
using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public abstract partial class StateBase : StateTreeItem
{
    public StateBase Parent { get; set; }

    private readonly HashSet<Transition> _transitions = [];

    public override void _Ready()
    {
        foreach (var child in GetChildren())
            if (child is Transition transition)
                _transitions.Add(transition);
    }

    public virtual void UpdateLogic(double delta)
    {
        foreach (var transition in _transitions)
            if (transition.CheckCondition())
            {
                HandleTransition(transition.To.Name, []);
                return;
            }
    }

    public virtual void UpdatePhysic(double delta) { }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void HandleEvent() { }

    public virtual void HandleTransition(string to, HashSet<string> processed) { }

    public override string ToString() => Name;

    public virtual void Leaf(IStateTreeVisitor visitor) { }
}
