using UnityEngine;
using UnityEngine.Events;

public class BaseEnemyAttack : IEnemyAttack
{
    public EnemyAttackSO AttackSO;

    private float _fireRateTemp;
    private float _fireRate;
    private Transform _targetPosition;
    private BaseTowerHealth _targetTowerHealth;

    public BaseEnemyAttack(EnemyAttackSO attackSo)
    {
        AttackSO = attackSo;
        _fireRate = AttackSO.FireRate;
    }
    

    public void AttackAction()
    {
        if(InRange(_targetPosition) == false) return;
        
        AttackRate(_targetTowerHealth.Damage,AttackSO);
    }

    private bool InRange(Transform targetPosition)
    {
        return targetPosition.position.magnitude <= AttackSO.Range;
    }

    private void AttackRate(UnityAction<float,ElementType> attackAction,EnemyAttackSO attackSo)
    {
        _fireRateTemp += Time.deltaTime;

        if (_fireRateTemp > _fireRate)
        {
            _fireRate += Time.deltaTime;
            attackAction?.Invoke(attackSo.AttackPower,attackSo.AttackElement);
        }
    }
}