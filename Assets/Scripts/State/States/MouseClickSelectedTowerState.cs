using UnityEngine;

public class MouseClickSelectedTowerState : MouseClickBaseState
{
    private BaseTower _selectedTower;
    private readonly int _towerLayerMask;
    
    private readonly IdleInputReader _idleInputReader;
    private readonly MouseClickStateEvents _mouseClickStateEvents;
    private readonly PopupManager _popupManager;
    private readonly SelectedTowerReceiver _selectedTowerReceiver;
    
    private string TowerStatPopupName = "TowerStatPopup";
    
    public MouseClickSelectedTowerState(MouseClickStateMachine mouseClickStateMachine, 
        IdleInputReader idleInputReader, MouseClickStateEvents mouseClickStateEvents, PopupManager popupManager,
        SelectedTowerReceiver selectedTowerReceiver) 
        : base(mouseClickStateMachine)
    {
        _idleInputReader = idleInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
        _popupManager = popupManager;
        _selectedTowerReceiver = selectedTowerReceiver;
        
        _towerLayerMask = 1 << 8;
    }

    public override void OnEnter()
    {
        _mouseClickStateEvents.OnTowerBuildStart += OnTowerBuildingClick;
        _idleInputReader.OnTowerSelected += OnTowerSelected;
        _idleInputReader.Enable();
        
        // Tower ui elementlerini aç
    }
    
    public override void OnUpdate(float deltaTime)
    {
           
        
    }

    public override void OnExit()
    {
        _selectedTower = null;
        _selectedTowerReceiver.SelectedTower = null;
        _popupManager.ClosePopupByName(TowerStatPopupName);
        
        _mouseClickStateEvents.OnTowerBuildStart -= OnTowerBuildingClick;
        _idleInputReader.OnTowerSelected -= OnTowerSelected;
        _idleInputReader.Disable();
        // Tower ui elementlerini kapa
    }

    private void OnTowerSelected()
    {
        _selectedTower = _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(_towerLayerMask);
        
        OpenTowerStatPopup();
    }

    private void OpenTowerStatPopup()
    {
        if (_selectedTower == null)
        {
            _popupManager.ClosePopupByName(TowerStatPopupName);
            return;
        }
        
        _selectedTowerReceiver.SelectedTower = _selectedTower;
        _popupManager.OpenPopupByNameWithPosition(TowerStatPopupName, _selectedTower.transform, (Vector3.right + Vector3.up) * 5f); 
    }
    
    private void OnTowerBuildingClick()
    {
        _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseGhostBuildState);
    }
}