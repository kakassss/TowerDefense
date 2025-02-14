using System;
using System.Collections.Generic;

public class BoxTower : BaseTower, IUpdate, IDisposable
{
    protected override void Construct(QuaternionUtils quaternionUtils, BaseTowerAttack attack, TowerAttackTypeHolder towerAttackTypeHolder,
        UpdateProvider updateProvider, TowerRangeTypeHolder towerRangeTypeHolder, GridSOData gridSoData)
    {
        base.Construct(quaternionUtils, attack, towerAttackTypeHolder, updateProvider, towerRangeTypeHolder,gridSoData);
        
        _updateProvider.AddListener(this);       
    }

    protected override void SetTowerStats()
    {
        base.SetTowerStats();
        
        HealthStages = new Dictionary<int, int>()
        {
            { 1, 100 },
        };
        
        IRangeTypeType = _towerRangeTypeHolder.RangeTypes[(int)RangeTypeEnum.BoxRange];
        TowerHealth = new BaseTowerHealth(HealthStages,ElementType.Normal);
    }

    public void UpdateBehavior()
    {
        AttackAction();
    }

    private void OnDisable()
    {
        _updateProvider.RemoveListener(this);
    }

    private void OnDestroy()
    {
        _updateProvider.RemoveListener(this);
    }

    public void Dispose()
    {
        _updateProvider.RemoveListener(this);
    }
}
