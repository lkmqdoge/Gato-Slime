using Godot;

namespace GatoSlime.Game.Props;

[GlobalClass]
public partial class LiquidBody : Node2D
{
    [Export]
    public int Amount = 30;

    [Export]
    public int Passes = 8;

    public float k = 0.015f;
    public float d = 0.03f;
    public float spread = 0.0002f;
    public float Gap = 8;

    private LiquidSpring[] _springs;

    public override void _Ready()
    {
        _springs = new LiquidSpring[Amount];
        for (int i = 0; i < _springs.Length; i++)
            _springs[i] = new LiquidSpring();

        Splash(2, 5);
    }


    public override void _PhysicsProcess(double delta)
    {
        foreach (var spring in _springs)
            spring.Update(k, d);

        var len = _springs.Length;
        var leftDeltas = new float[len];
        var rightDeltas = new float[len];

        for (int j = 0; j > Passes; j++)
        {
            for (int i = 1; i < len; i++)
            {
                leftDeltas[i] = spread * (_springs[i].Height - _springs[i - 1].Height);
                _springs[i - 1].Velocity += leftDeltas[i];
            }

            for (int i = len - 2; i > 0; i--)
            {
                rightDeltas[i] = spread * (_springs[i].Height - _springs[i + 1].Height);
                _springs[i + 1].Velocity += rightDeltas[i];
            }
        }
        QueueRedraw();
    }

    // public override void _Draw()
    // {
    //     for (int i = 0; i < _springs.Length - 1; i++)
    //         DrawCircle(
    //             ,
    //             5,
    //             new Color(1, 0, 0)
    //         );
    // }

    // public Vector2[] GetPoints()
    // {
    //     var res = new Vector2[Amount];
    //     for (int i = 0; i < Amount; i++)
    //     {
    //         res[i] = new Vector2(i * Gap - Amount * 6, _springs[i].Position.Y);
    //     }
    //     return res;
    // }

    public void Splash(int idx, float Speed)
    {
        if (idx >= 0 && idx < _springs.Length)
            _springs[idx].Velocity += Speed;
    }
}
