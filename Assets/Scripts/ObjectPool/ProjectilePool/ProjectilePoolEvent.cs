using System;
using UnityEngine;
public class ProjectilePoolEvent
{
    private Action<Vector3,Transform> _onProjectileEnable;
    private Action<BaseProjectile> _onProjectileDeactivated;

    public void FireActivate(Vector3 targetDirection,Transform position)
    {
        _onProjectileEnable?.Invoke(targetDirection,position);
    }

    public void AddProjectileEnable(Action<Vector3,Transform> action)
    {
        _onProjectileEnable += action;
    }

    public void RemoveProjectileEnable(Action<Vector3,Transform> action)
    {
        _onProjectileEnable -= action;
    }
    public void FireDeactivated(BaseProjectile gameObject)
    {
        _onProjectileDeactivated?.Invoke(gameObject);
    }

    public void AddDeactivatedListener(Action<BaseProjectile> action)
    {
        _onProjectileDeactivated += action;
    }

    public void RemoveDeactivatedListener(Action<BaseProjectile> action)
    {
        _onProjectileDeactivated -= action;
    }
}