using Zenject;

public class MouseClickStateMachine : StateMachine
{
    //Stored states
    public MouseClickSelectedTowerState MouseClickSelectedTowerState;
    public MouseGhostBuildState MouseGhostBuildState;
    
    //Manager References
    public Utils Utils;
    
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;
    private PopupManager _popupManager;
    private TowerAttackTypeReceiver _towerAttackTypeReceiver;
    
    //Readers
    private BuildingInputReader _buildingInputReader;
    private IdleInputReader _idleInputReader;
    
    //Events
    private MouseClickStateEvents _mouseClickStateEvents;
    
    [Inject]
    protected void Construct(Utils utils, CellManager cellManager, GhostObjectReceiver ghostObjectReceiver
    , BuildingInputReader buildingInputReader, IdleInputReader idleInputReader, MouseClickStateEvents mouseClickStateEvents,
    TowerAttackTypeReceiver towerAttackTypeReceiver, PopupManager popupManager)
    {
        //Public references
        Utils = utils;
        //Private references
        _cellManager = cellManager;
        _ghostObjectReceiver = ghostObjectReceiver;
        _buildingInputReader = buildingInputReader;
        _idleInputReader = idleInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
        _popupManager = popupManager;
        _towerAttackTypeReceiver = towerAttackTypeReceiver;
        
        //Public constructers
        MouseClickSelectedTowerState = new MouseClickSelectedTowerState(this,_idleInputReader,_mouseClickStateEvents,_popupManager,_towerAttackTypeReceiver);
        MouseGhostBuildState = new MouseGhostBuildState(this,_ghostObjectReceiver,_cellManager,_buildingInputReader,_mouseClickStateEvents);
    }

    private void Start()
    {
        SwitchState(MouseClickSelectedTowerState);
    }
}