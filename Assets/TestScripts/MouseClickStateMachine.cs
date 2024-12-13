using Zenject;

public class MouseClickStateMachine : StateMachine
{
    //Stored states
    public MouseClickSelectedTowerState MouseClickSelectedTowerState;
    public MouseGhostBuildState MouseGhostBuildState;
    
    //Manager References
    public Utils Utils;
    
    protected GhostObjectReceiver _ghostObjectReceiver;
    protected CellManager _cellManager;
    
    //Readers
    private BuildingInputReader _buildingInputReader;
    private IdleInputReader _idleInputReader;
    
    //Events
    protected MouseClickStateEvents _mouseClickStateEvents;
    
    [Inject]
    protected void Construct(Utils utils, CellManager cellManager, GhostObjectReceiver ghostObjectReceiver
    , BuildingInputReader buildingInputReader, IdleInputReader idleInputReader, MouseClickStateEvents mouseClickStateEvents)
    {
        //Public references
        Utils = utils;
        //Private references
        _cellManager = cellManager;
        _ghostObjectReceiver = ghostObjectReceiver;
        _buildingInputReader = buildingInputReader;
        _idleInputReader = idleInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
        
        MouseClickSelectedTowerState = new MouseClickSelectedTowerState(this,_idleInputReader,_mouseClickStateEvents);
        MouseGhostBuildState = new MouseGhostBuildState(this,_ghostObjectReceiver,_cellManager,_buildingInputReader,_mouseClickStateEvents);
    }

    private void Start()
    {
        SwitchState(MouseClickSelectedTowerState);
    }
}