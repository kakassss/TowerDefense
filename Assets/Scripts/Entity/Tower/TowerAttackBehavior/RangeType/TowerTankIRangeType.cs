using UnityEngine;

public class TowerTankIRangeType : IRangeType
{
    public bool InRange(Transform enemyPosition, Transform towerPosition, BaseTowerAttackSO towerAttackSo)
    {
        return false;
    }
}