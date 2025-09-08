using Godot;

namespace GatoSlime.UI;

public class UIFactory
{
    public static Control CreateUIElement(string path) => CreateUIElement<Control>(path);

    public static T CreateUIElement<T>(string path)
        where T : Node
    {
        if (!ResourceLoader.Exists(path))
            return null;

        var elem = ResourceLoader.Load<PackedScene>(path);
        return elem.Instantiate<T>();
    }
}
