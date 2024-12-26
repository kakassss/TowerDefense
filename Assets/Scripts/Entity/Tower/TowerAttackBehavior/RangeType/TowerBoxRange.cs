using UnityEngine;

public class TowerBoxRange : IRange
{
    public bool InRange(Transform enemyPosition, Transform towerPosition, BaseTowerAttackSO towerAttackSo)
    {
        return enemyPosition.position.x - towerPosition.position.x <= towerAttackSo.Range 
               && Mathf.Approximately(enemyPosition.position.z, towerPosition.position.z);
    }
}