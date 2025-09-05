using GatoSlime.Common;
using GatoSlime.UI;
using Godot;

namespace GatoSlime.Game;

public partial class Main : Node
{
    public SceneManager SceneManager { get; private set; }
    public UIFactory UIFactory { get; private set; } = new();

    public override void _Ready()
    {
        SceneManager = GetNode<SceneManager>("%SceneManager");
        SceneManager.ChangeUIScene(UIFactory.CreateUIElement("uid://cff7jokir16xc"));
    }
}
