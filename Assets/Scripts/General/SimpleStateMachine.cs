using System.Collections.Generic;
using System.Linq;
using UnityEngine;

abstract public class SimpleStateMachine<T> : MonoBehaviour where T : SimpleStateMachine<T> {

    private IList<ISimpleState<T>> _states;
    private ISimpleState<T> _currentState;

    abstract protected IList<ISimpleState<T>> CreateStates();

    public void SetState<U>() where U : ISimpleState<T> {
        if (_currentState != null)
            _currentState.OnStateExit((T)this);
        _currentState = _states.OfType<U>().First();
        _currentState.OnStateEnter((T)this);
    }

    private void SetState<U>(U state) where U : ISimpleState<T> {
        SetState<U>();
    }

    protected void Awake() {
        _states = CreateStates();
    }

    protected void Start() {
        SetState(_states.First());
    }

    protected void Update() {
        _currentState.Update((T)this);
    }

}