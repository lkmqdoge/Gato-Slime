using GatoSlime.Common;
using Godot;
using System;

public partial class Main : Node
{
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(GameConstants.DebugReload))
            GetTree().ReloadCurrentScene();
    }
}
