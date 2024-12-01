
public class EnemyGoblin : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        base.Construct(enemyPoolEvent);
        EnemyID = new EnemyID(1);
    }

    protected override void SetEnemyStats()
    {
        base.SetEnemyStats();
        //Movement.speed = 3f;
    }

    private void Update()
    {
        Movement.TranslateForward(Transform);
    }
}