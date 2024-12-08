using UnityEngine;

public abstract class MouseClickBaseState : State
{
    protected readonly MouseClickStateMachine _mouseClickStateMachine;
    
    protected MouseClickBaseState(MouseClickStateMachine mouseClickStateMachine)
    {
        _mouseClickStateMachine = mouseClickStateMachine;
    }
}

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
        // Tower ui elementlerini aç
    }

    public override void OnUpdate(float deltaTime)
    {
        _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(towerLayerMask);   
    }

    public override void OnExit()
    {
        // Tower ui elementlerini kapa
    }
}