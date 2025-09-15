using Godot;

namespace GatoSlime.UI;

public partial class UIManager : Node
{
    public static UIManager Instance { get; private set; }

    [Export]
    public Control PauseLayer { get; private set; }

    [Export]
    public Control DebugLayer { get; private set; }

    [Export]
    public Control HUDLayer { get; private set; }

    public override void _Ready()
    {
        Instance = this;

        PauseLayer.Hide();
        DebugLayer.Hide();
        HUDLayer.Hide();
    }

    public void ShowPause()
    {
        PauseLayer.Show();
    }

    public void HidePause()
    {
        PauseLayer.Hide();
        GetTree().Paused = false;
    }
}
