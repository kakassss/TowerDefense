using Zenject;

public class MouseClickStateMachine : StateMachine
{
    public Utils Utils;

    public MouseClickSelectedTowerState MouseClickSelectedTowerState;
    public MouseObjectBuildState MouseObjectBuildState;
    
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;
    [Inject]
    protected void Construct(Utils utils, CellManager cellManager, GhostObjectReceiver ghostObjectReceiver)
    {
        //Public references
        Utils = utils;
        //Private references
        _cellManager = cellManager;
        _ghostObjectReceiver = ghostObjectReceiver;
        
        MouseClickSelectedTowerState = new MouseClickSelectedTowerState(this);
        MouseObjectBuildState = new MouseObjectBuildState(this,_ghostObjectReceiver,_cellManager);
    }

    private void Start()
    {
        SwitchState(MouseClickSelectedTowerState);
    }
}