using Godot;

namespace GatoSlime.Game.World;

public partial class Stage : Node2D
{
    private WorldGenerator _worldGenerator;

    public override void _Ready()
    {
        _worldGenerator = GetNode<WorldGenerator>("%WorldGenerator");
    }
}
