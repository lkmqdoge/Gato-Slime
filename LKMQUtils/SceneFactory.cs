using System;
using System.Collections.Generic;
using Godot;

namespace LKMQUtils;

public partial class SceneFactory : Node
{
    protected Dictionary<string, string> _uids;

    public Node CreateElement(string key) => CreateElement<Node>(key);

    public T CreateElement<T>(string key)
        where T : Node
    {
        if (!_uids.TryGetValue(key, out var uid))
            throw new ArgumentException($"Scene {key} not found");

        var elem = ResourceLoader.Load<PackedScene>(uid);
        return elem.Instantiate<T>();
    }
}
