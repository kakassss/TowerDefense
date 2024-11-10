using Zenject;

public class BuildSelectManager
{
    private GridEntitySO _currentGridEntitySO;

    public GridEntitySO CurrentGridEntitySO => _currentGridEntitySO;

    private InputActions _inputActions;

    [Inject]
    private void Construct(InputActions inputActions)
    {
        _inputActions = inputActions;
        
        _inputActions.GhostSpawnInputAddAction(SetGhostObjectSelect);
    }
    
    private void SetGhostObjectSelect(GridEntitySO gridEntitySo)
    {
        _currentGridEntitySO = gridEntitySo;
    }
}