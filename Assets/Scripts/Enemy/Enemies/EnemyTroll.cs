
public class EnemyTroll : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        base.Construct(enemyPoolEvent);
        EnemyID = new EnemyID(2);
    }
}
