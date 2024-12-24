using System;
using UnityEngine;
public class ProjectilePoolEvent
{
    public Action<Vector3,Transform,IEnemy,float> OnProjectileEnable;
    public Action<BaseProjectile> OnProjectileDeactivated;
}