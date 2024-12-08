using UnityEngine;

public class MouseClickSelectedTowerState : MouseClickBaseState
{
    private BaseTower _selectedTower;
    private readonly int towerLayerMask;
    
    private IdleInputReader _idleInputReader;
    
    public MouseClickSelectedTowerState(MouseClickStateMachine mouseClickStateMachine, IdleInputReader idleInputReader) : base(mouseClickStateMachine)
    {
        _idleInputReader = idleInputReader;
        towerLayerMask = 1 << 8;
    }

    public override void OnEnter()
    {
        _idleInputReader.Enable();
        Debug.Log("yokoso minnassan hideo kojima dess");
        // Tower ui elementlerini aç
    }

    public override void OnUpdate(float deltaTime)
    {
        _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(towerLayerMask);   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseGhostBuildState);
        }
    }

    public override void OnExit()
    {
        _idleInputReader.Disable();
        // Tower ui elementlerini kapa
    }
}