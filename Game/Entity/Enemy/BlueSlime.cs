using Godot;

namespace GatoSlime.Enemy;

[GlobalClass]
public partial class BlueSlime : BaseEnemy
{
    public override void Die()
    {
        QueueFree();
    }

    public override void TakeDamage(int amount) { }
}
