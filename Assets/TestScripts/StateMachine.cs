using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State _currentState;
    
    public void SwitchState(State newState)
    {
        _currentState?.OnExit();
        _currentState = newState;
        _currentState?.OnEnter();
    }

    private void Update()
    {
        _currentState?.OnUpdate(Time.deltaTime);
    }
}
