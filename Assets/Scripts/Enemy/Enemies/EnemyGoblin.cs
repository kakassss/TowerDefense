
public class EnemyGoblin : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        base.Construct(enemyPoolEvent);
        EnemyID = new EnemyID(1);
    }
    
    private void Update()
    {
        Movement.TranslateForward(transform);
    }
}