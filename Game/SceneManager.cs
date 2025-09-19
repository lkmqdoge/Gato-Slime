using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game;

public partial class SceneManager : Node
{
    public static SceneManager Instance { get; private set; }

    [Export]
    public Node Root { get; set; }

    [Export]
    public Node UIRoot { get; set; }

    public Node CurrentScene { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.DebugReload))
            GetTree().ReloadCurrentScene();
    }

    public void ChangeScene(Node scene)
    {
        if (scene is not null)
        {
            CurrentScene?.QueueFree();
            CurrentScene = scene;

            if (scene is Control)
                UIRoot.AddChild(scene);
            else
                Root.AddChild(scene);
        }
    }
}
