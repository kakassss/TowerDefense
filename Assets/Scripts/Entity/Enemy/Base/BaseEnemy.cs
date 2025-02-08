using UnityEngine;
using Zenject;

//Enemy IDs
//0 Troll
//1 Goblin

//TODO: Enemyler öldükten sonra poola geri gelip sonra tekrar kullanılabildiklerine bakmadın
public struct EnemyID
{
    public int ID;
    public EnemyID(int id) => ID = id;
}

public abstract class BaseEnemy : MonoBehaviour,IEnemy
{
    public BaseEnemyHealth Health { get; private set; }
    public BaseEnemyDefence Defence { get; private set; }
    public BaseEnemyAttack Attack { get; private set;}
    public EnemyID EnemyID { get; protected set; }
    public Transform Transform => transform;

    [SerializeField] protected EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] protected EnemyAttackSO _enemyAttackSo;
    [SerializeField] protected BaseEnemyDataSO _baseEnemyDataSo;
    [SerializeField] private Rigidbody _rigidbody;
    
    private EnemyPoolEvent _enemyPoolEvent;
    private MovementUtils _movementUtils;
    
    [Inject]
    protected virtual void Construct(EnemyPoolEvent enemyPoolEvent, MovementUtils movementUtils, BaseEnemyAttack attack
    ,BaseEnemyDefence defence)
    {
        _enemyPoolEvent = enemyPoolEvent;
        _movementUtils = movementUtils;
        Attack = attack;
        Defence = defence;
        
        SetEnemyStats();
    }

    protected virtual void SetEnemyStats()
    {
        // Defence = new BaseEnemyDefence
        // {
        //     DefenceSo = _enemyDefenceSo
        // };
        Defence.SetDefenceSO(_enemyDefenceSo);
        Attack.SetAttackSO(_enemyAttackSo);
        //Attack = new BaseEnemyAttack(_enemyAttackSo);// bunu singleton yapabilirsin 
        Health = new BaseEnemyHealth(Defence.DefenceSo.Health,Defence.DefenceSo.DefenceType)
        {
            Death = this
        };
    }

    protected virtual void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _movementUtils.TranslateForward(Transform,_baseEnemyDataSo.MovementSpeed,_rigidbody);
    }
    
    private void OnDisable()
    {
        _enemyPoolEvent.FireDeactivated(this,EnemyID);
    }

    public void Death()
    {
        Transform.gameObject.SetActive(false);
        transform.position = Vector3.one * 25f;
        transform.rotation = Quaternion.identity;
    }
}

