
public class EnemyTroll : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent,MovementUtils movementUtils
        , BaseEnemyAttack attack, BaseEnemyDefence defence, BaseEnemyAnimator animator)
    {
        base.Construct(enemyPoolEvent, movementUtils, attack, defence, animator);
        EnemyID = new EnemyID(0);
    }
    
    protected override void SetEnemyStats()
    {
        base.SetEnemyStats();
    }

    
}
