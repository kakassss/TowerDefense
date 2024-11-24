using System;

public class EnemyPoolEvent
{
    private Action<BaseEnemy> OnEnemyDeactivated;
    
    public void FireDeactivated(BaseEnemy gameObject)
    {
        OnEnemyDeactivated?.Invoke(gameObject);
    }

    public void AddDeactivatedListener(Action<BaseEnemy> action)
    {
        OnEnemyDeactivated += action;
    }

    public void RemoveDeactivatedListener(Action<BaseEnemy> action)
    {
        OnEnemyDeactivated -= action;
    }
}
