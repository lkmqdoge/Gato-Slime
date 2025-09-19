using Godot;

namespace GatoSlime.Game.World;

[GlobalClass]
public partial class LevelData : Resource
{
    [Export(PropertyHint.File, "*.tscn")]
    public string SourcePath { get; private set; }
}
