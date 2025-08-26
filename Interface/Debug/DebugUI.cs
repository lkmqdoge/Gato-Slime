using System;
using GatoSlime.Game.Player;
using Godot;

namespace GatoSlime.Interface.Debug;

public partial class DebugUI : Node
{
    [Export]
    private Player _player;

    private Label _stateLabel;

    private Label _velocityLabel;

    private Label _fpsLabel;

    public override void _Ready()
    {
        base._Ready();

        _stateLabel = GetNode<Label>("%StateLabel");
        _velocityLabel = GetNode<Label>("%VelocityLabel");
        _fpsLabel = GetNode<Label>("%FPSLabel");

        _player.StateTree.LeafActive += OnStateChanged;
    }

    public override void _Process(double delta)
    {
        if (_player is not null)
            _velocityLabel.Text = $"Velocity: {_player.StateTree.BlackBoard["velocity"]}";

        _fpsLabel.Text = $"FPS: {Engine.GetFramesPerSecond()}";
    }

    public override void _ExitTree()
    {
        _player.StateTree.LeafActive -= OnStateChanged;
    }

    private void OnStateChanged(StateBase state)
    {
        _stateLabel.Text = $"Current State: {state}";
    }
}
