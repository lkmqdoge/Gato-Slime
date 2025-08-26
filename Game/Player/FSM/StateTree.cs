using System;
using System.Collections.Generic;
using Godot;

namespace GatoSlime.Game.Player;

[GlobalClass]
public partial class StateTree : Node
{
    public event Action<StateBase> LeafActive;

    [Export]
    public Godot.Collections.Dictionary<string, Variant> BlackBoard { get; private set; } = [];

    [Export]
    private bool _debug = false;

    private readonly HashSet<string> _events = [];

    private readonly Dictionary<string, StateBase> _states = [];

    public override void _Ready()
    {
        SetupChildren(this);
        foreach (var child in GetChildren())
            if (child is StateBase state)
                _states.Add(state.Name, state);
    }

    public override void _PhysicsProcess(double delta)
    {
        foreach (var state in _states.Values)
            state.UpdatePhysic(delta);
    }

    public override void _Process(double delta)
    {
        foreach (var state in _states.Values)
            state.UpdateLogic(delta);

        _events.Clear();
    }

    public void PushEvent(string @event) => _events.Add(@event);

    public void InvokeLeaf(AtomicState leaf) => LeafActive?.Invoke(leaf);

    public bool HasEvent(string @event)
    {
        var res = _events.TryGetValue(@event, out _);

        if (res)
        {
            // GD.Print($"event {@event} is proccesed");
            _events.Remove(@event);
        }
        return res;
    }

    private void SetupChildren(Node node)
    {
        foreach (var child in node.GetChildren())
        {
            if (child.GetChildCount() > 0)
                SetupChildren(child);

            if (child is StateTreeItem stateTreeItem)
                stateTreeItem.Root = this;
        }
    }
}
