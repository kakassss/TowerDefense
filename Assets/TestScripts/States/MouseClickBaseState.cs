
public abstract class MouseClickBaseState : State
{
    protected readonly MouseClickStateMachine _mouseClickStateMachine;
    
    protected MouseClickBaseState(MouseClickStateMachine mouseClickStateMachine)
    {
        _mouseClickStateMachine = mouseClickStateMachine;
    }
}