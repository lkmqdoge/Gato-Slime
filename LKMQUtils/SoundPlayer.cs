using System.Collections.Generic;
using Godot;

namespace LKMQUtils;

public partial class SoundPlayer : Node
{
    protected Dictionary<string, AudioStream> _sounds;

    [Export]
    AudioStreamPlayer _player;

    public void Play(string path)
    {
        if (_sounds.TryGetValue(path, out var stream))
        {
            _player.Stream = stream;
            _player.Play();
            return;
        }

        Logger.Info($"Sound {path} does not exists");
    }

    partial class UIDS;
}
