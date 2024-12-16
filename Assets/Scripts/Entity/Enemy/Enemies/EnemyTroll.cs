using Random = UnityEngine.Random;

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

    private void Update()
    {
        _movementUtils.TranslateForward(Transform,_baseEnemyDataSo.MovementSpeed * Random.Range(1,3));
    }
}
