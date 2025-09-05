using GatoSlime.Game;
using GatoSlime.Game.World;
using Godot;

namespace GatoSlime.UI;

public partial class MainMenu : Control
{
    private Button _playButton;

    public override void _Ready()
    {
        _playButton = GetNode<Button>("%PlayButton");
        _playButton.Connect(BaseButton.SignalName.Pressed, Callable.From(OnStartPressed));
    }

    private void OnStartPressed()
    {
        SceneManager.Instance.ChangeScene(
            ResourceLoader.Load<PackedScene>("uid://dsogacyl3drsd").Instantiate<Stage>()
        );
        SceneManager.Instance.ChangeUIScene(null);
    }
}
