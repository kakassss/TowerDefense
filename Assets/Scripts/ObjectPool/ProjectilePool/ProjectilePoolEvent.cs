using System;
using UnityEngine;
public class ProjectilePoolEvent
{
    private Action<BaseProjectile> OnProjectileDeactivated;
    private Action<Vector3> _onProjectileEnable;

    public void FireActivate(Vector3 targetDirection)
    {
        _onProjectileEnable?.Invoke(targetDirection);
    }

    public void AddProjectileEnable(Action<Vector3> action)
    {
        _onProjectileEnable += action;
    }

    public void RemoveProjectileEnable(Action<Vector3> action)
    {
        _onProjectileEnable -= action;
    }
    public void FireDeactivated(BaseProjectile gameObject)
    {
        OnProjectileDeactivated?.Invoke(gameObject);
    }

    public void AddDeactivatedListener(Action<BaseProjectile> action)
    {
        OnProjectileDeactivated += action;
    }

    public void RemoveDeactivatedListener(Action<BaseProjectile> action)
    {
        OnProjectileDeactivated -= action;
    }
}