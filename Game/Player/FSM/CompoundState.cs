using System.Collections.Generic;
using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public partial class CompoundState : StateBase
{
    [Export]
    private StateBase _initialState;

    private StateBase _currentState;

    private readonly Dictionary<string, StateBase> _nestedStates = [];
    private readonly List<CompoundState> _nestedCompound = [];

    public override void _Ready()
    {
        base._Ready();
        _currentState = _initialState;
        foreach (var child in GetChildren())
        {
            if (child is StateBase state)
            {
                state.Parent = this;
                _nestedStates.Add(child.Name, state);
            }

            if (child is CompoundState compoundState)
                _nestedCompound.Add(compoundState);
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdatePhysic(double delta)
    {
        base.UpdatePhysic(delta);
        _currentState.UpdatePhysic(delta);
    }

    public override void UpdateLogic(double delta)
    {
        base.UpdateLogic(delta);
        _currentState.UpdateLogic(delta);
    }

    public sealed override void HandleTransition(string to, HashSet<string> processed)
    {
        if (_nestedStates.TryGetValue(to, out StateBase state))
        {
            SetState(state);
            Parent?.HandleTransition(Name, processed);
        }
        else
        {
            processed.Add(Name);
            if (Parent is not null && !processed.Contains(Parent.Name))
                Parent.HandleTransition(to, processed);

            foreach (var nested in _nestedCompound)
                if (!processed.Contains(nested.Name))
                    nested.HandleTransition(to, processed);
        }
    }

    public sealed override void Leaf(IStateTreeVisitor visitor)
    {
        visitor.HandleCompoundState(this);
        _currentState.Leaf(visitor);
    }

    private void SetState(StateBase state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
