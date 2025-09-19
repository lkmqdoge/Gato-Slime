using GatoSlime.Common;
using GatoSlime.Game;
using Godot;

namespace GatoSlime.UI;

public partial class MainMenu : Control
{
    private Button _playButton;
    private Button _debugButton;

    public override void _Ready()
    {
        _playButton = GetNode<Button>("%PlayButton");
        _debugButton = GetNode<Button>("%DebugButton");
        _playButton.Connect(BaseButton.SignalName.Pressed, Callable.From(OnStartPressed));
        _debugButton.Connect(BaseButton.SignalName.Pressed, Callable.From(OnDebugPressed));
    }

    private void OnDebugPressed()
    {
        SceneManager.Instance.ChangeScene(Main.Instance.SceneFactory.CreateElement("Debug001"));
    }


    private void OnStartPressed()
    {
        SceneManager.Instance.ChangeScene(Main.Instance.SceneFactory.CreateElement("Stage"));
    }
}
