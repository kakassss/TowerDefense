using Zenject;

public class MouseClickStateMachine : StateMachine
{
    public Utils Utils;

    public MouseClickSelectedTowerState MouseClickSelectedTowerState;
    public MouseGhostBuildState MouseGhostBuildState;
    
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;
    
    private BuildingInputReader _buildingInputReader;
    private IdleInputReader _idleInputReader;
    
    [Inject]
    protected void Construct(Utils utils, CellManager cellManager, GhostObjectReceiver ghostObjectReceiver
    , BuildingInputReader buildingInputReader, IdleInputReader idleInputReader)
    {
        //Public references
        Utils = utils;
        //Private references
        _cellManager = cellManager;
        _ghostObjectReceiver = ghostObjectReceiver;
        _buildingInputReader = buildingInputReader;
        _idleInputReader = idleInputReader;
        
        
        
        MouseClickSelectedTowerState = new MouseClickSelectedTowerState(this,_idleInputReader);
        MouseGhostBuildState = new MouseGhostBuildState(this,_ghostObjectReceiver,_cellManager,_buildingInputReader);
    }

    private void Start()
    {
        SwitchState(MouseClickSelectedTowerState);
    }
}