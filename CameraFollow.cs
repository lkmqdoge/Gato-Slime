using System;
using Godot;

namespace GatoSlime.Game;

[GlobalClass]
public partial class CameraFollow : Camera2D
{
    [Export]
    public Node2D Target { get; set; }

    [Export]
    public float VerticalWeight;

    [Export]
    public float HorizontalWeight;

    public override void _Process(double delta)
    {
        Follow(delta);
    }

    private void Follow(double delta)
    {
        if (Target is null)
            return;

        var a = GlobalPosition;
        var b = Target.GlobalPosition;

        // var x = Mathf.MoveToward(a.X, b.X, HorizontalWeight * (float)delta);
        // var y = Mathf.MoveToward(a.Y, b.Y, VerticalWeight * (float)delta);
        var x = (b.X - a.X) * HorizontalWeight * (float)delta;
        var y = (b.Y - a.Y) * VerticalWeight * (float)delta;
        GlobalPosition += new Vector2(x, y);
    }
}
