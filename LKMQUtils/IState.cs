namespace LKMQUtils;

public interface IState
{
    void Enter();

    void Exit();

    void UpdateLogic(double delta);

    void UpdatePhysic(double delta);
}
