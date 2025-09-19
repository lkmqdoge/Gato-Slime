using GatoSlime.Common;
using GatoSlime.Entity;
using GatoSlime.Game.World;
using Godot;
using LKMQUtils;

namespace GatoSlime.Game.Props;

[GlobalClass]
public partial class PlayerSpawner : Node2D
{
    [Signal]
    public delegate void PlayerSpawnedEventHandler(Player.Player player);

    [Signal]
    public delegate void PlayerDiedEventHandler();

    Timer _respawnTimer;
    Player.Player _player;
    AudioStreamPlayer _deathSound;
    CpuParticles2D _deathEffect;

    bool _has_player;

    public override void _Ready()
    {
        _respawnTimer = GetNode<Timer>("%RespawnTimer");
        _deathSound = GetNode<AudioStreamPlayer>("%DeathSound");
        _deathEffect = GetNode<CpuParticles2D>("%DeathEffect");
        _respawnTimer.Connect(Timer.SignalName.Timeout, Callable.From(OnRespawnTimerTimeout));
    }

    public void SpawnPlayer()
    {
        if (_has_player)
            return;

        _player = Main.Instance.SceneFactory.CreateElement<Player.Player>("Player");
        AddChild(_player);
        _player.Health.Connect(Health.SignalName.Died, Callable.From(OnPlayerDied));
        EmitSignal(SignalName.PlayerSpawned, _player);
        _has_player = true;
    }

    private void OnPlayerDied()
    {
        Logger.Debug("Player has died");
        _has_player = false;

        _deathEffect.GlobalPosition = _player.GlobalPosition;
        _deathEffect.Emitting = true;

        var camera = (SceneManager.Instance.CurrentScene as BaseLevel).CameraFollow;
        camera.ApplyShake();

        _deathSound.Play();

        _player.QueueFree();
        _respawnTimer.Start();
        EmitSignal(SignalName.PlayerDied);
    }

    private void OnRespawnTimerTimeout() => SpawnPlayer();
}
