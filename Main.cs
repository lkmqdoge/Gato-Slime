using GatoSlime.Common;
using GatoSlime.UI;
using Godot;
using LKMQUtils;

namespace GatoSlime.Game;

public partial class Main : Node
{
    public SceneManager SceneManager { get; private set; }

    public UIManager UIManager { get; private set; }

    public UISoundPlayer UISoundPlayer { get; private set; }

    public SceneFactory SceneFactory { get; private set; }

    public static Main Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;

        SceneFactory = GetNode<SceneFactory>("%SceneFactory");
        SceneManager = GetNode<SceneManager>("%SceneManager");
        UIManager = GetNode<UIManager>("%UIManager");
        UISoundPlayer = GetNode<UISoundPlayer>("%UISoundPlayer");

        SceneManager.ChangeScene(SceneFactory.CreateElement("MainMenu"));
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.DebugShowCollisions))
            GetTree().DebugCollisionsHint = !GetTree().DebugCollisionsHint;
    }
}
