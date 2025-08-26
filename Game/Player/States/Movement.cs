using System;
using Godot;

namespace GatoSlime.Game.Player;

public partial class Movement : CompoundState
{
    [Export]
    private CharacterBody2D _body;

    public override void UpdatePhysic(double delta)
    {
        base.UpdatePhysic(delta);

        var acceleration = (float)Root.BlackBoard["acceleration"];
        var friction = (float)Root.BlackBoard["friction"];
        var speed = (float)Root.BlackBoard["speed"];
        var velocity = (Vector2)Root.BlackBoard["velocity"];
        var direction = (Vector2)Root.BlackBoard["direction"];

        float dX;
        if (direction.X != 0.0f)
            dX = Mathf.MoveToward(velocity.X, speed * direction.X, (float)delta * acceleration);
        else
            dX = Mathf.MoveToward(velocity.X, 0.0f, (float)delta * friction);

        Root.BlackBoard["velocity"] = new Vector2(_body.IsOnWall() ? direction.X : dX, velocity.Y);
    }
}
