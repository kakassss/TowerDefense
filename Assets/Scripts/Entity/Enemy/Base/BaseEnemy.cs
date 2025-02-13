using System;
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
    
    public BaseEnemyAnimator Animator { get; private set; }
    public Transform Transform => transform;

    [Header("References")]
    [SerializeField] protected EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] protected EnemyAttackSO _enemyAttackSo;
    [SerializeField] protected BaseEnemyDataSO _baseEnemyDataSo;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    
    private EnemyPoolEvent _enemyPoolEvent;
    private MovementUtils _movementUtils;
    private CellManager _cellManager;
    protected UpdateProvider _updateProvider;

    private ITower _targetTower;
    private const int TowerLayerMask = 1 << 8;
    private int _rayCastDistance = 1;
    [Inject]
    protected virtual void Construct(EnemyPoolEvent enemyPoolEvent, MovementUtils movementUtils, BaseEnemyAttack attack
    ,BaseEnemyDefence defence, BaseEnemyAnimator animator, UpdateProvider updateProvider, CellManager cellManager)
    {
        _enemyPoolEvent = enemyPoolEvent;
        _movementUtils = movementUtils;
        _updateProvider = updateProvider;
        _cellManager = cellManager;
        
        Attack = attack;
        Defence = defence;
        Animator = animator;
        
        SetEnemyStats();
    }

    private void OnEnable()
    {
        LookAtGridCenter();
    }

    private void OnDisable()
    {
        _enemyPoolEvent.FireDeactivated(this,EnemyID);
    }

    protected virtual void SetEnemyStats()
    {
        // Defence = new BaseEnemyDefence
        // {
        //     DefenceSo = _enemyDefenceSo
        // };
        Defence.SetDefenceSO(_enemyDefenceSo);
        Attack.SetAttackSO(_enemyAttackSo);
        Animator.SetAnimator(_animator);
        
        Health = new BaseEnemyHealth(Defence.DefenceSo.Health,Defence.DefenceSo.DefenceType)
        {
            Death = this
        };
    }

    private void LookAtGridCenter()
    {
        transform.LookAt(_cellManager.GetMidCellPosition());
    }
    
    protected void StateBehavior()
    {
        if(gameObject.activeInHierarchy == false) return;
        
        if (_movementUtils.TranslateForward(Transform,_baseEnemyDataSo.MovementSpeed,_rigidbody,Animator) == true)
        {
            return;
        }
        
        if (_movementUtils.IsTargetValid(transform.position, -transform.right, _rayCastDistance, TowerLayerMask) == false)
        {
            Attack.AttackRate(_enemyAttackSo,Animator);
            return;
        }
        
        Animator.SetIdle();
    }
    
    public void Death()
    {
        Transform.gameObject.SetActive(false);
        transform.position = Vector3.one * 25f;
        transform.rotation = Quaternion.identity;
    }
}

