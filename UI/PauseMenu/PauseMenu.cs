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

        _continueButton.Pressed += OnContinuePressed;
        _optionsButton.Pressed += OnOptionsPressed;
        _exitButton.Pressed += OnExitPressed;
    }

    public override void _ExitTree()
    {
        _continueButton.Pressed -= OnContinuePressed;
        _optionsButton.Pressed -= OnOptionsPressed;
        _exitButton.Pressed -= OnExitPressed;
    }


    private void OnExitPressed()
    {
        SceneManager.Instance.ChangeScene(SceneFactory.CreateElement("MainMenu"));
        UIManager.Instance.HidePause();
    }


    private void OnOptionsPressed()
    {
    }


    private void OnContinuePressed()
    {
        UIManager.Instance.HidePause();
    }
}
