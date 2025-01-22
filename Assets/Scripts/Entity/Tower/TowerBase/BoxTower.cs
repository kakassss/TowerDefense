using System;

public class BoxTower : BaseTower, IUpdate, IDisposable
{
    protected override void Construct(QuaternionUtils quaternionUtils, BaseTowerAttack attack, TowerAttackTypeHolder towerAttackTypeHolder,
        UpdateProvider updateProvider, TowerRangeTypeHolder towerRangeTypeHolder)
    {
        base.Construct(quaternionUtils, attack, towerAttackTypeHolder, updateProvider, towerRangeTypeHolder);
        
        _updateProvider.AddListener(this);       
    }

    protected override void SetTowerStats()
    {
        base.SetTowerStats();
        IRangeTypeType = _towerRangeTypeHolder.RangeTypes[(int)RangeTypeEnum.BoxRange];
        Health = new BaseHealth(100,ElementType.Normal);
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
