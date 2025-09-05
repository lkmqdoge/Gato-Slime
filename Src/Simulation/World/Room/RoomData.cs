using Godot;

namespace GatoSlime.Game.World;

[GlobalClass]
public partial class RoomData : Resource
{
    [Export]
    public int Width { get; private set; } = 12;

    [Export]
    public int Height { get; private set; } = 20;

    [Export(PropertyHint.File, "*.tscn")]
    public string SourcePath { get; private set; }

    [Export]
    public Godot.Collections.Array<string> Tags { get; private set; } = [];
}
