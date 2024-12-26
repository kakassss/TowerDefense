public class SphereTower : BaseTower
{
    protected override void SetTowerStats()
    {
        base.SetTowerStats();
        RangeType = _towerAttackTypeHolder.RangeTypes[(int)RangeTypeEnum.Sphere];
        Health = new BaseHealth(100,ElementType.Normal);
    }
}
