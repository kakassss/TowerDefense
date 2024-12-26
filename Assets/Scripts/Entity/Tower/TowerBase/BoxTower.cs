public class BoxTower : BaseTower
{
    protected override void SetTowerStats()
    {
        base.SetTowerStats();
        RangeType = _towerAttackTypeHolder.RangeTypes[(int)RangeTypeEnum.Box];
        Health = new BaseHealth(100,ElementType.Normal);
    }
}
