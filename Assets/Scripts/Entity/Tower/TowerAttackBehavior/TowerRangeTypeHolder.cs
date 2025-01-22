using System.Collections.Generic;

public class TowerRangeTypeHolder
{
    private readonly List<IRangeType> _rangeTypes;
    
    public List<IRangeType> RangeTypes => _rangeTypes;

    private TowerRangeTypeHolder(TowerBoxIRangeType towerBoxIRangeType, TowerSphereIRangeType towerSphereIRangeType,
        TowerTankIRangeType towerTankIRangeType)
    {
        _rangeTypes = new List<IRangeType>()
        {
            towerSphereIRangeType,
            towerBoxIRangeType,
            towerTankIRangeType
        };
    }
}

public enum RangeTypeEnum
{
    SphereRange = 0,
    BoxRange = 1,
    NoRange = 2,
}