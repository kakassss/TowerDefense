
public class EnemyGoblin : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent, MovementUtils movementUtils)
    {
        base.Construct(enemyPoolEvent,movementUtils);
        EnemyID = new EnemyID(1);
    }

    protected override void SetEnemyStats()
    {
        base.SetEnemyStats();
    }

    private void Update()
    {
        _movementUtils.TranslateForward(Transform,_baseEnemyDataSo.MovementSpeed);
    }
}