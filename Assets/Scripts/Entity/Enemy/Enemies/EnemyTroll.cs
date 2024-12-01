
public class EnemyTroll : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        base.Construct(enemyPoolEvent);
        EnemyID = new EnemyID(0);
    }
    
    protected override void SetEnemyStats()
    {
        base.SetEnemyStats();
        Movement.speed = 2f;
    }

    private void Update()
    {
        Movement.TranslateForward(Transform);
    }
}
