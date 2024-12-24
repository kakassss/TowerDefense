
public class EnemyTroll : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent,MovementUtils movementUtils)
    {
        base.Construct(enemyPoolEvent, movementUtils);
        EnemyID = new EnemyID(0);
    }
    
    protected override void SetEnemyStats()
    {
        base.SetEnemyStats();
    }

    
}
