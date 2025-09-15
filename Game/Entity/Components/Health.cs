using Godot;

namespace GatoSlime.Entity;

[GlobalClass]
public partial class Health : Node
{
    [Export(PropertyHint.Range, "0,99,1")]
    public int Max { get; set; }

    public int Current { get; set; }
}
