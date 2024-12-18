using UnityEngine;

public class MouseClickSelectedTowerState : MouseClickBaseState
{
    private BaseTower _selectedTower;
    private readonly int _towerLayerMask;
    
    private readonly IdleInputReader _idleInputReader;
    private readonly MouseClickStateEvents _mouseClickStateEvents;
    private readonly PopupManager _popupManager;
    private readonly TowerAttackTypeReceiver _towerAttackTypeReceiver;
    
    private string TowerStatPopupName = "TowerStatPopup";
    
    public MouseClickSelectedTowerState(MouseClickStateMachine mouseClickStateMachine, 
        IdleInputReader idleInputReader, MouseClickStateEvents mouseClickStateEvents, PopupManager popupManager,
        TowerAttackTypeReceiver towerAttackTypeReceiver) 
        : base(mouseClickStateMachine)
    {
        _idleInputReader = idleInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
        _popupManager = popupManager;
        _towerAttackTypeReceiver = towerAttackTypeReceiver;
        
        _towerLayerMask = 1 << 8;
    }

    public override void OnEnter()
    {
        _mouseClickStateEvents.OnTowerBuildStart += OnTowerBuildingClick;
        _idleInputReader.OnTowerSelected += OnTowerSelected;
        _idleInputReader.Enable();
        
        //Debug.Log("yokoso minnassan hideo kojima dess");
        // Tower ui elementlerini aç
    }
    
    public override void OnUpdate(float deltaTime)
    {
           
        
    }

    public override void OnExit()
    {
        _selectedTower = null;
        _towerAttackTypeReceiver.SelectedTower = null;
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
        
        _towerAttackTypeReceiver.SelectedTower = _selectedTower;
        _popupManager.InstantiatePopupByName(TowerStatPopupName);
    }
    
    private void OnTowerBuildingClick()
    {
        _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseGhostBuildState);
    }
}