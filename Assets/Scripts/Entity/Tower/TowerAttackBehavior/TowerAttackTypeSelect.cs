using System;
using UnityEngine;
using Zenject;

public class TowerAttackTypeEvent
{
    private Action _onAttackTypeChanged;

    public void FireOnAttackTypeChanged()
    {
        _onAttackTypeChanged?.Invoke();
    }

    public void AddOnAttackTypeChanged(Action action)
    {
        _onAttackTypeChanged += action;
    }

    public void RemoveOnAttackTypeChanged(Action action)
    {
        _onAttackTypeChanged -= action;
    }
    
}

public class TowerAttackTypeSelect : MonoBehaviour
{
    public ITargetToEnemy SelectedTarget;

    private TowerAttackTypeEvent _towerAttackTypeEvent;
    
    [Inject]
    private void Construct(TowerAttackTypeHolder towerAttackTypeHolder,TowerAttackTypeEvent towerAttackTypeEvent)
    {
        _towerAttackTypeEvent = towerAttackTypeEvent;
        //Not necessary for now
        //SelectedTarget = towerAttackTypeHolder.AttackTypes[0]; // Set Closest Attack type as default
    }

    public void ChangeAttackType(ITargetToEnemy target)
    {
        SelectedTarget = target;
        _towerAttackTypeEvent.FireOnAttackTypeChanged();
    }
}
