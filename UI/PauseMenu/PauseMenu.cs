using GatoSlime.Common;
using GatoSlime.Game;
using Godot;

namespace GatoSlime.UI;

public partial class PauseMenu : Control
{
    private Button _continueButton;
    private Button _optionsButton;
    private Button _exitButton;

    public override void _Ready()
    {
        _continueButton = GetNode<Button>("%ContinueButton");
        _optionsButton = GetNode<Button>("%OptionsButton");
        _exitButton = GetNode<Button>("%ExitButton");

        _continueButton.Connect(BaseButton.SignalName.Pressed, Callable.From(OnContinuePressed));
        _optionsButton.Connect(BaseButton.SignalName.Pressed, Callable.From(OnOptionsPressed));
        _exitButton.Connect(BaseButton.SignalName.Pressed, Callable.From(OnExitPressed));
    }

    private void OnExitPressed()
    {
        SceneManager.Instance.ChangeScene(Main.Instance.SceneFactory.CreateElement("MainMenu"));
        UIManager.Instance.HidePause();
    }

    private void OnOptionsPressed() { }

    private void OnContinuePressed()
    {
        UIManager.Instance.HidePause();
        Main.Instance.UISoundPlayer.Play("pause_out");
    }
}
