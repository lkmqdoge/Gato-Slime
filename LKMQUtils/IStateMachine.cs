namespace LKMQUtils;

public interface IStateMachine
{
    void AddState<T>(T state)
        where T : IState;

    void SetState<T>()
        where T : IState;

    void UpdateLogic(double delta);

    void UpdatePhysic(double delta);
}
