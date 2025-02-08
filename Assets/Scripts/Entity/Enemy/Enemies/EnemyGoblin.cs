
public class EnemyGoblin : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent, MovementUtils movementUtils
        , BaseEnemyAttack enemyAttack, BaseEnemyDefence defence)
    {
        base.Construct(enemyPoolEvent,movementUtils, enemyAttack, defence);
        EnemyID = new EnemyID(1);
    }

    protected override void SetEnemyStats()
    {
        base.SetEnemyStats();
    }
    
}