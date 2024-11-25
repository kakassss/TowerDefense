using System;

public class EnemyPoolEvent
{
    private Action<BaseEnemy,EnemyID> OnEnemyDeactivated;
    
    public void FireDeactivated(BaseEnemy gameObject,EnemyID index)
    {
        OnEnemyDeactivated?.Invoke(gameObject,index);
    }

    public void AddDeactivatedListener(Action<BaseEnemy,EnemyID> action)
    {
        OnEnemyDeactivated += action;
    }

    public void RemoveDeactivatedListener(Action<BaseEnemy,EnemyID> action)
    {
        OnEnemyDeactivated -= action;
    }
}
