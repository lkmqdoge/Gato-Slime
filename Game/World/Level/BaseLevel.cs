using GatoSlime.Game.Props;
using Godot;

namespace GatoSlime.Game.World;

public partial class BaseLevel : Node2D
{
    public CameraFollow CameraFollow { get; private set; }

    public PlayerSpawner PlayerSpawner { get; private set; }

    public override void _Ready()
    {
        PlayerSpawner = GetNode<PlayerSpawner>("%PlayerSpawner");
        CameraFollow = GetNode<CameraFollow>("%CameraFollow");
        PlayerSpawner.Connect(
            PlayerSpawner.SignalName.PlayerSpawned,
            Callable.From<Player.Player>(OnPlayerSpawned)
        );
        PlayerSpawner.Connect(PlayerSpawner.SignalName.PlayerDied, Callable.From(OnPlayerDied));
        PlayerSpawner.SpawnPlayer();
    }

    private void OnPlayerDied()
    {
        CameraFollow.Target = null;
    }

    private void OnPlayerSpawned(Player.Player player)
    {
        CameraFollow.Target = player;
    }
}
