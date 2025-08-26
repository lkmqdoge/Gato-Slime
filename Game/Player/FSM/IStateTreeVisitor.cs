namespace GatoSlime.Game.Player;

public interface IStateTreeVisitor
{
    void HandleCompoundState(CompoundState state);
    void HandleAtomicState(StateBase state);
}