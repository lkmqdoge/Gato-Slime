using GatoSlime.Common;
using Godot;

namespace GatoSlime.Game.Props;

[GlobalClass]
public partial class PlayerSpawner : Node2D
{
    public void SpawnPlayer()
    {
        var player = SceneFactory.CreateElement<Player.Player>("Player");
        AddChild(player);
    }
}
