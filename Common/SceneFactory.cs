using System;
using System.Collections.Generic;
using Godot;

namespace GatoSlime.Common;

public static class SceneFactory
{
    private static readonly Dictionary<string, string> _uids = new()
    {
        { "MainMenu", GameConstants.UIDS.MainMenu },
        { "PauseMenu", GameConstants.UIDS.PauseMenu },
        { "Stage", GameConstants.UIDS.Stage },
        { "Debug001", GameConstants.UIDS.Debug001 },
        { "OptionsMenu", GameConstants.UIDS.OptionsMenu },
    };

    public static Node CreateElement(string key) => CreateElement<Node>(key);

    public static T CreateElement<T>(string key)
        where T : Node
    {
        if (!_uids.TryGetValue(key, out var uid))
            throw new ArgumentException($"Scene {key} not found");

        var elem = ResourceLoader.Load<PackedScene>(uid);
        return elem.Instantiate<T>();
    }
}
