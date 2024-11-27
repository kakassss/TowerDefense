
using System;

public class EnemyTroll : BaseEnemy
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        base.Construct(enemyPoolEvent);
        EnemyID = new EnemyID(0);
    }

    private void Update()
    {
        Movement.TranslateForward(transform);
    }
}
