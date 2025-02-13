
public class EnemyGoblin : BaseEnemy, IUpdate
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent, MovementUtils movementUtils,
        BaseEnemyAttack enemyAttack, BaseEnemyDefence defence, BaseEnemyAnimator animator,
        UpdateProvider updateProvider, CellManager cellManager)
    {
        base.Construct(enemyPoolEvent,movementUtils, enemyAttack, defence, animator, updateProvider,cellManager);
        EnemyID = new EnemyID(1);
        
        _updateProvider.AddListener(this);
    }
    
    public void UpdateBehavior()
    {
        StateBehavior();
    }
}