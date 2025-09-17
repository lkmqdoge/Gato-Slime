using GatoSlime.Game.Player;
using Godot;

namespace GatoSlime.UI;

public partial class HUD : Control
{
    public Player Player { get; set; }

    private Label _healthLabel;

    public override void _Ready()
    {
        _healthLabel = GetNode<Label>("%HealthLabel");
    }
}
