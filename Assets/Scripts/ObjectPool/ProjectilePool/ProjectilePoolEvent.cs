using System;
using UnityEngine;
public class ProjectilePoolEvent
{
    public Action<Vector3,Transform,IEnemy,BaseTowerAttackSO> OnProjectileEnable;
    public Action<BaseProjectile> OnProjectileDeactivated;
}