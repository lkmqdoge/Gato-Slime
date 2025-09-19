using System.Collections.Generic;
using Godot;
using LKMQUtils;

namespace GatoSlime.UI;

public partial class UISoundPlayer : SoundPlayer
{
    UISoundPlayer()
    {
        _sounds = new()
        {
            { "pause_in", ResourceLoader.Load<AudioStream>(UIDS.PauseIn) },
            { "pause_out", ResourceLoader.Load<AudioStream>(UIDS.PauseOut) },
            { "button_press", new() },
        };
    }

    class UIDS
    {
        public const string PauseIn = "uid://bkdu4appghftu";
        public const string PauseOut = "uid://c61rfsbbb4y87";
    }
}
