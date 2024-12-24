using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAttack
{
    protected ProjectilePool _projectilePool;
    protected ProjectilePoolEvent _projectilePoolEvent;
    
    protected const int enemyLayerMask = 1 << 9;
    protected float _fireRateTemp;
    
    public BaseTowerAttack(ProjectilePool projectilePool, ProjectilePoolEvent projectilePoolEvent)
    {
        _projectilePool = projectilePool;
        _projectilePoolEvent = projectilePoolEvent;
    }
    
    public bool InRange(Transform enemyPosition,Transform towerPosition,BaseTowerAttackSO towerAttackSo)
    {
        float distance = Vector3.Distance(enemyPosition.position, towerPosition.position);
        return distance <= towerAttackSo.Range;
    }
    
    public void AttackRate(IEnemy enemy, Transform towerAimPoint,BaseTowerAttackSO towerAttackSo)
    {
        _fireRateTemp += Time.deltaTime;
        
        if (_fireRateTemp > towerAttackSo.FireRate)
        {
            // Send data to projectile
            _projectilePoolEvent.OnProjectileEnable?.Invoke(enemy.Transform.position,towerAimPoint,enemy,towerAttackSo.Damage);
            _projectilePool.GetAvailableObject().transform.position = towerAimPoint.position; // Projectile Spawn at certain position
            _fireRateTemp = 0;
        }
    }
}