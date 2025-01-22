using UnityEngine;

public interface IAttackType
{
    IEnemy TargetAction(Transform transform,BaseTowerAttackSO towerAttackSo);
}