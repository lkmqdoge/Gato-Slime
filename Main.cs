using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game;

public partial class Main : Node
{
    public SceneManager SceneManager { get; private set; }

    public override void _Ready()
    {
        SceneManager = GetNode<SceneManager>("%SceneManager");
        SceneManager.ChangeScene(SceneFactory.CreateElement("MainMenu"));
    }
}
