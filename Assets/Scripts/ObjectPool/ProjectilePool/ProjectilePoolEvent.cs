using System;

public class ProjectilePoolEvent
{
    private Action<BaseProjectile> OnProjectileDeactivated;
    
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