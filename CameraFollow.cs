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

    [Export]
    public float RandomStrength { get; set; } = 30.0f;

    [Export]
    public float ShakeFade { get; set; } = 5.0f;

    RandomNumberGenerator _rng = new();

    float _shakeStrength = 0.0f;

    public override void _Process(double delta)
    {
        Follow(delta);

        if (_shakeStrength > 0)
        {
            _shakeStrength = Mathf.Lerp(_shakeStrength, 0, ShakeFade * (float)delta);
            Offset = RandomOffset();
        }
    }

    public void ApplyShake() => _shakeStrength = RandomStrength;

    private Vector2 RandomOffset() =>
        new(
            _rng.RandfRange(-_shakeStrength, _shakeStrength),
            _rng.RandfRange(-_shakeStrength, _shakeStrength)
        );

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
