
public class BuildObjectReceiver
{
    private BaseObject _currentGridEntitySO;

    public BaseObject CurrentGridEntitySO => _currentGridEntitySO;

    private BuildingInputEvents _buildingInputEvents;

    public BuildObjectReceiver(BuildingInputEvents buildingInputEvents)
    {
        _buildingInputEvents = buildingInputEvents;
        
        _buildingInputEvents.GhostSpawnInputAddAction(SetGhostObjectSelect);
    }
    
    private void SetGhostObjectSelect(BaseObject gridEntitySo)
    {
        _currentGridEntitySO = gridEntitySo;
    }
}