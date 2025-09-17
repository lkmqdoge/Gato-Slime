using System;
using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class Health : Node
{
    public event Action<int> CurrentChanged;
    public event Action<int> MaxChanged;

    [Export(PropertyHint.Range, "0,99,1")]
    public int Max
    {
        get => _max;
        set { _max = value; }
    }

    public int Current
    {
        get => _current;
        set { _current = value; }
    }

    private int _max;

    private int _current;

    public override void _Ready()
    {
        Current = Max;
    }
}
