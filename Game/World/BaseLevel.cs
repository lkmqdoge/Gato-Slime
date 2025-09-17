using GatoSlime.Game.Props;
using Godot;

namespace GatoSlime.Game.World;

public partial class BaseLevel : Node2D
{
    PlayerSpawner _playerSpawner;

    public override void _Ready()
    {
        _playerSpawner = GetNode<PlayerSpawner>("%PlayerSpawner");
    }
}
