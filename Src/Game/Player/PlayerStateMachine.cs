using System;
using System.Collections.Generic;
using LKMQUtils;

namespace GatoSlime.Game.Player;

public class PlayerStateMachine : IStateMachine
{
    public event Action<Type> StateUpdated;

    private readonly Dictionary<Type, IState> _states = [];
    private IState _currentState;

    public void UpdateLogic(double delta) => _currentState.UpdateLogic(delta);

    public void UpdatePhysic(double delta) => _currentState.UpdatePhysic(delta);

    public Type GetState() => _currentState.GetType();

    public void AddState<T>(T state)
        where T : IState
    {
        _states.Add(typeof(T), state);
    }

    public void SetState<T>()
        where T : IState
    {
        if (_states.TryGetValue(typeof(T), out IState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();

            StateUpdated?.Invoke(_currentState.GetType());
            return;
        }
    }
}