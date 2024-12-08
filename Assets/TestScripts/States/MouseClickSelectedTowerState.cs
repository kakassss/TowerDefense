using UnityEngine;

public class MouseClickSelectedTowerState : MouseClickBaseState
{
    private BaseTower _selectedTower;
    private readonly int towerLayerMask;
    
    public MouseClickSelectedTowerState(MouseClickStateMachine mouseClickStateMachine) : base(mouseClickStateMachine)
    {
        towerLayerMask = 1 << 8;
    }

    public override void OnEnter()
    {
        Debug.Log("yokoso minnassan hideo kojima dess");
        // Tower ui elementlerini aç
    }

    public override void OnUpdate(float deltaTime)
    {
        _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(towerLayerMask);   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseObjectBuildState);
        }
    }

    public override void OnExit()
    {
        
        
        // Tower ui elementlerini kapa
    }
}