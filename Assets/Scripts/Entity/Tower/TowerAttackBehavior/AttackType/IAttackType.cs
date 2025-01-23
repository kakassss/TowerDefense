using UnityEngine;

public interface IAttackType
{
    IEnemy AttackType(Transform transform,BaseTowerAttackSO towerAttackSo);
}