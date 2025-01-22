using UnityEngine;

public interface IRangeType
{
    bool InRange(Transform enemyPosition, Transform towerPosition, BaseTowerAttackSO towerAttackSo);
}