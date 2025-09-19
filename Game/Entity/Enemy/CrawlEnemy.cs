using GatoSlime.Enemy;
using Godot;

namespace GatoSlime.Game.Entity;

public partial class CrawlEnemy : BaseEnemy
{
    public float CrawlSpeed { get; set; } = 30.0f;

    int _rotating;
    Vector2 _move;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (_rotating != 0)
        {
            Rotation = Mathf.LerpAngle(Rotation, _move.Angle(), 0.1f);
            _rotating -= 1;
        }

        var col = MoveAndCollide(_move * CrawlSpeed * (float)delta);
        if (col != null && col.GetNormal().Rotated(Mathf.Pi / 2).Dot(_move) < 0.5f)
        {
            _rotating = 4;
            _move = col.GetNormal().Rotated(Mathf.Pi / 2);
            return;
        }

        var pos = Position;
        col = MoveAndCollide(_move.Rotated(Mathf.Pi / 2) * 15);
        if (col is null)
        {
            for (int i = 0; i < 10; i++)
            {
                Position = pos;
                Rotate(Mathf.Pi / 32);
                _move = _move.Rotated(Mathf.Pi / 32);
                col = MoveAndCollide(_move.Rotated(Mathf.Pi / 2) * 15);
                if (col is not null)
                {
                    _move = col.GetNormal().Rotated(Mathf.Pi / 2);
                    Rotation = _move.Angle();
                    break;
                }
            }
        }
        else
        {
            _move = col.GetNormal().Rotated(Mathf.Pi / 2);
            Rotation = _move.Angle();
        }
    }

    public override void Die() { }
}
