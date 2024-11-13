using Zenject;

public class BuildSelectManager
{
    private BaseObject _currentGridEntitySO;

    public BaseObject CurrentGridEntitySO => _currentGridEntitySO;

    private InputActions _inputActions;

    [Inject]
    private void Construct(InputActions inputActions)
    {
        _inputActions = inputActions;
        
        _inputActions.GhostSpawnInputAddAction(SetGhostObjectSelect);
    }
    
    private void SetGhostObjectSelect(BaseObject gridEntitySo)
    {
        _currentGridEntitySO = gridEntitySo;
    }
}