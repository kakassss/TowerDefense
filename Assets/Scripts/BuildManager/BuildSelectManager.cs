using Zenject;

public class BuildSelectManager
{
    private BaseObject _currentGridEntitySO;

    public BaseObject CurrentGridEntitySO => _currentGridEntitySO;

    private BuildingInputEvents _buildingInputEvents;

    [Inject]
    private void Construct(BuildingInputEvents buildingInputEvents)
    {
        _buildingInputEvents = buildingInputEvents;
        
        _buildingInputEvents.GhostSpawnInputAddAction(SetGhostObjectSelect);
    }
    
    private void SetGhostObjectSelect(BaseObject gridEntitySo)
    {
        _currentGridEntitySO = gridEntitySo;
    }
}