using GatoSlime.UI;
using Godot;

namespace GatoSlime.Game;

public partial class HudController : Node
{
    [Export]
    private Player.Player _player;

    public override void _Ready()
    {
        // UIManager.Instance.
    }
}
