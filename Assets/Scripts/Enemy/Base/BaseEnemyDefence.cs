using UnityEngine;
using UnityEngine.Events;

public class BaseEnemyDefence : IEnemyDefence
{
    public EnemyDefenceSO DefenceSo;
    
    public bool DefenceAction(int defenceValue,ElementType elementType)
    {
        if (DefenceSo.FireDefence <= defenceValue 
            && elementType == DefenceSo.DefenceType) return false;
        
        Debug.Log("Observed");
        return true;
    }
}

public class BaseEnemyAttack : IEnemyAttack
{
    public EnemyAttackSO AttackSO;

    private float _fireRateTemp;
    private float _fireRate;
    private Transform _targetPosition;
    private BaseHealth _targetHealth;

    public BaseEnemyAttack(EnemyAttackSO attackSo)
    {
        AttackSO = attackSo;
        _fireRate = AttackSO.FireRate;
    }
    

    public void AttackAction()
    {
        if(InRange(_targetPosition) == false) return;
        
        AttackRate(_targetHealth.Damage,AttackSO.AttackPower);
    }

    private bool InRange(Transform targetPosition)
    {
        return targetPosition.position.magnitude <= AttackSO.Range;
    }

    private void AttackRate(UnityAction<float> attackAction,float damage)
    {
        _fireRateTemp += Time.deltaTime;

        if (_fireRateTemp > _fireRate)
        {
            _fireRate += Time.deltaTime;
            attackAction?.Invoke(damage);
        }
    }
}