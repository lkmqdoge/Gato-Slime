using System;
using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class Health : Node
{
    public event Action<int> DamageTaken;
    public event Action<int> MaxChanged;

    [Signal]
    public delegate void DiedEventHandler();

    [Export(PropertyHint.Range, "0,99,1")]
    public int Max
    {
        get => _max;
        set { _max = value; }
    }

    public int Current { get; private set; }

    private int _max;
    private bool _is_died;

    public override void _Ready()
    {
        Current = Max;
    }

    public void TakeDamage(int amount)
    {
        Current = Mathf.Clamp(Current - amount, 0, Max);
        DamageTaken?.Invoke(amount);

        if (!_is_died && Current == 0)
        {
            _is_died = true;
            EmitSignal(SignalName.Died);
        }
    }
}
