using Godot;

namespace GatoSlime.Autoload;

public partial class AppConfig : Node
{
    public static AppConfig Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }
}
