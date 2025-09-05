using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game;

public partial class SceneManager : Node
{
    public static SceneManager Instance { get; private set; }

    [Export]
    private Node2D _world2DRoot;

    [Export]
    private Control _UIRoot;

    private Node2D _currentScene;
    private Control _currentUI;

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.DebugReload))
            GetTree().ReloadCurrentScene();
    }

    public void ChangeScene(Node2D scene)
    {
        ClearNodeChildren(_currentScene);

        if (scene is not null)
            _world2DRoot.AddChild(scene);

        _currentScene = scene;
    }

    public void ChangeUIScene(Control scene)
    {
        ClearNodeChildren(_currentUI);

        if (scene is not null)
            _UIRoot.AddChild(scene);

        _currentUI = scene;
    }

    public Node2D GetCurrentScene() => _currentScene;

    public Control GetCurrentUI() => _currentUI;

    private void ClearNodeChildren(Node node)
    {
        if (node is null)
            return;

        foreach (var child in node.GetChildren())
            child.QueueFree();
    }
}
