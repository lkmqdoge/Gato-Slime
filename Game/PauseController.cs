using GatoSlime.Common;
using GatoSlime.Game;
using GatoSlime.UI;
using Godot;

public partial class PauseController : Node
{
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.Pause))
        {
            UIManager.Instance.ShowPause();
            Main.Instance.UISoundPlayer.Play("pause_in");
            GetTree().Paused = true;
        }
    }
}
