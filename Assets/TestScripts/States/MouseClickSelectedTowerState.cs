using UnityEngine;

public class MouseClickSelectedTowerState : MouseClickBaseState
{
    private BaseTower _selectedTower;
    private readonly int towerLayerMask;
    
    private IdleInputReader _idleInputReader;
    private MouseClickStateEvents _mouseClickStateEvents;
    
    public MouseClickSelectedTowerState(MouseClickStateMachine mouseClickStateMachine, IdleInputReader idleInputReader, MouseClickStateEvents mouseClickStateEvents) : base(mouseClickStateMachine)
    {
        _idleInputReader = idleInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
        
        towerLayerMask = 1 << 8;
    }

    public override void OnEnter()
    {
        _mouseClickStateEvents.OnTowerBuildStart += OnTowerBuildingClick;
        _idleInputReader.Enable();
        
        Debug.Log("yokoso minnassan hideo kojima dess");
        // Tower ui elementlerini aç
    }

    public override void OnUpdate(float deltaTime)
    {
        _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(towerLayerMask);   
    }

    public override void OnExit()
    {
        _mouseClickStateEvents.OnTowerBuildStart += OnTowerBuildingClick;
        _idleInputReader.Disable();
        // Tower ui elementlerini kapa
    }

    private void OnTowerBuildingClick()
    {
        _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseGhostBuildState);
    }
}