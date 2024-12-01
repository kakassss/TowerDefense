using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public abstract class BaseTower : MonoBehaviour, ITower, ITowerAttacker
{
    public BaseTowerAttack Attack { get; private set;}
    public BaseHealth Health { get; private set;}
    
    [SerializeField] protected BaseTowerAttackSO _towerAttackSo;
    
    protected List<IEnemy> _enemies;
    protected IEnemy _targetEnemy;
    
    protected ProjectilePool _projectilePool;
    
    [Inject]
    protected void Construct(ProjectilePool projectilePool)
    {
        _projectilePool = projectilePool;
        SetTowerStats();
    }

    protected virtual void SetTowerStats()
    {
        _enemies = new List<IEnemy>();
        
        Attack = new BaseTowerAttack(_towerAttackSo,_projectilePool);
        Health = new BaseHealth(100);
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (!other.TryGetComponent(out IEnemy enemy)) return;
    //     
    //     _enemies.Add(enemy);
    //     Debug.Log("Enemy added");
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     if (!other.TryGetComponent(out IEnemy enemy)) return;
    //     
    //     _enemies.Remove(enemy);
    //     Debug.Log("Enemy removed");
    // }
    //
    
    
    public void AttackAction()
    {
        if (_targetEnemy == null)
        {
            //Debug.Log("Find targ");
            _targetEnemy = Attack.DetectEnemies(transform);
        }
        
        if(_targetEnemy == null) return;
        
        if (Attack.InRange(_targetEnemy.Transform,transform) == false)
        {
            _targetEnemy = null;
            return;
        }
        
        Debug.Log("attacking to target " + _targetEnemy.Transform.name);
        Attack.AttackRate(_targetEnemy.Health.Damage,_targetEnemy);
    }
    
    void OnDrawGizmos()
    {
        // Gizmo'nun rengini ayarla
        Gizmos.color = Color.magenta;

        // Küre çiz (transform'un pozisyonunda ve targetingRange yarıçapında)
        Gizmos.DrawWireSphere(transform.position, _towerAttackSo.Range);
    }

    
    // public void AttackAction()
    // {
    //     if(_enemies.Count <= 0) return;
    //
    //     if (_targetEnemy == null)
    //     {
    //         _targetEnemy = Attack.FindClosestEnemy(transform, _enemies);
    //     }
    //     
    //     Attack.AttackRate(_targetEnemy.Health.Damage,_targetEnemy);
    // }
}