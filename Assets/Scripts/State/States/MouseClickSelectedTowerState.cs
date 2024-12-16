using UnityEngine;

public class MouseClickSelectedTowerState : MouseClickBaseState
{
    private BaseTower _selectedTower;
    private readonly int towerLayerMask;
    
    private IdleInputReader _idleInputReader;
    private MouseClickStateEvents _mouseClickStateEvents;
    private PopupManager _popupManager;
    
    private string TowerStatPopupName = "TowerStatPopup";
    
    public MouseClickSelectedTowerState(MouseClickStateMachine mouseClickStateMachine, 
        IdleInputReader idleInputReader, MouseClickStateEvents mouseClickStateEvents, PopupManager popupManager) 
        : base(mouseClickStateMachine)
    {
        _idleInputReader = idleInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
        _popupManager = popupManager;
        
        towerLayerMask = 1 << 8;
    }

    public override void OnEnter()
    {
        _mouseClickStateEvents.OnTowerBuildStart += OnTowerBuildingClick;
        _idleInputReader.OnTowerSelected += OnTowerSelected;
        _idleInputReader.Enable();
        
        Debug.Log("yokoso minnassan hideo kojima dess");
        // Tower ui elementlerini aç
    }
    
    public override void OnUpdate(float deltaTime)
    {
           
        
    }

    public override void OnExit()
    {
        _selectedTower = null;
        
        _mouseClickStateEvents.OnTowerBuildStart += OnTowerBuildingClick;
        _idleInputReader.OnTowerSelected -= OnTowerSelected;
        _idleInputReader.Disable();
        // Tower ui elementlerini kapa
    }

    private void OnTowerSelected()
    {
        _selectedTower = _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(towerLayerMask);
        if (_selectedTower == null)
        {
            _popupManager.ClosePopupByName(TowerStatPopupName);
            return;
        }
        _popupManager.InstantiatePopupByName(TowerStatPopupName);
    }
    
    private void OnTowerBuildingClick()
    {
        _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseGhostBuildState);
    }
}