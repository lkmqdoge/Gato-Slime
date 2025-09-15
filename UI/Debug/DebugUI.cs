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
        _player.StateMachine.StateUpdated += (state) => {
            _stateLabel.Text = $"State: {state}";
        };
    }

    public override void _Process(double delta)
    {
        if (_player is not null)
            _velocityLabel.Text = $"Velocity: {_player.Velocity}";

        _fpsLabel.Text = $"FPS: {Engine.GetFramesPerSecond()}";
    }
}
