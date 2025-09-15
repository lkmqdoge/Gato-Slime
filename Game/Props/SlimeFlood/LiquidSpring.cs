using Godot;

namespace GatoSlime.Game.Props;

public class LiquidSpring
{
    public Vector2 Position = Vector2.Zero;
    public float Velocity = 0;
    public float Force = 0;
    public float Height;
    public float TargetHeight;
    public float K = 0.015f;

    public void Update(float springConstant, float dampening)
    {
        Height = Position.Y;

        var x = Height - TargetHeight;

        var loss = -dampening * Velocity;

        Force = -springConstant * x + loss;

        Velocity += Force;
        Position += new Vector2(0, Velocity);
    }
}
