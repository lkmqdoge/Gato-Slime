using System;
using Godot;
using LKMQUtils;

namespace Game;

public partial class GameManager : Node, IStateMachine
{
    public void AddState<T>(T state)
        where T : IState
    {
        throw new NotImplementedException();
    }

    public void SetState<T>()
        where T : IState
    {
        throw new NotImplementedException();
    }

    public void UpdateLogic(double delta)
    {
        throw new NotImplementedException();
    }

    public void UpdatePhysic(double delta)
    {
        throw new NotImplementedException();
    }
}
