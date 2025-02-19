﻿using UnityEngine;

public class TowerSphereIRangeType : IRangeType
{
    public bool InRange(Transform enemyPosition, Transform towerPosition, BaseTowerAttackSO towerAttackSo)
    {
        return Vector3.Distance(enemyPosition.position, towerPosition.position) <= towerAttackSo.Range;
    }
}