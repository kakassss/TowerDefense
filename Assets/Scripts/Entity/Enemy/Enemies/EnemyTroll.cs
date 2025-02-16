
public class EnemyTroll : BaseEnemy, IUpdate
{
    protected override void Construct(EnemyPoolEvent enemyPoolEvent,MovementUtils movementUtils,
        BaseEnemyAttack attack, BaseEnemyDefence defence, BaseEnemyAnimator animator,
        UpdateProvider updateProvider, CellManager cellManager)
    {
        base.Construct(enemyPoolEvent, movementUtils, attack, defence, animator, updateProvider, cellManager);
        EnemyID = new EnemyID(0);
        _updateProvider.AddListener(this);
    }
    
    public void UpdateBehavior()
    {
        StateMachine();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        
        _updateProvider.AddListener(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        
        _updateProvider.RemoveListener(this);
    }
}
