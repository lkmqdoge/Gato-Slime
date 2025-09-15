using GatoSlime.Common;
using GatoSlime.UI;
using Godot;

public partial class PauseController : Node
{
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.Pause))
        {
            UIManager.Instance.ShowPause();
            GetTree().Paused = true;
        }
    }
}
