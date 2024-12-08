using Zenject;

public class MouseClickStateMachine : StateMachine
{
    public Utils Utils;
    
    [Inject]
    protected void Construct(Utils utils)
    {
        Utils = utils;
    }
    
}