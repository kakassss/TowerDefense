using UnityEngine;

public class BaseEnemyAttack
{
    public EnemyAttackSO AttackSO;

    private float _fireRateTemp;
    private float _fireRate;
    private Transform _targetPosition;
    private BaseTowerHealth _targetTowerHealth;
    
    public void SetAttackSO(EnemyAttackSO attackSo)
    {
        AttackSO = attackSo;
        _fireRate = AttackSO.FireRate;
    }
    
    public void AttackRate(EnemyAttackSO attackSo, BaseEnemyAnimator animator)
    {
        _fireRateTemp += Time.deltaTime;

        if (_fireRateTemp > _fireRate)
        {
            _fireRate += Time.deltaTime;
            
            animator.SetAttacking();
        }
    }
}