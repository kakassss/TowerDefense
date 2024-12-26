using UnityEngine;

public interface ITargetToEnemy
{
    IEnemy TargetAction(Transform transform,BaseTowerAttackSO towerAttackSo);
}