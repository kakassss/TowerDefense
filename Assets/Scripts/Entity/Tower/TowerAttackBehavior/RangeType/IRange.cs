using UnityEngine;

public interface IRange
{
    bool InRange(Transform enemyPosition, Transform towerPosition, BaseTowerAttackSO towerAttackSo);
}