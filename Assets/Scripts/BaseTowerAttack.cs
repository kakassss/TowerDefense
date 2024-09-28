using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAttack
{
    public readonly ElementType ElementAttackType;
    public int Damage;
    public int Range;
    
    private float _fireRate;
    private float _fireRateTemp;
    
    public BaseTowerAttack(int damage, int range, int fireRate, ElementType elementAttackType)
    {
        Damage = damage;
        Range = range;
        _fireRate = fireRate;
        ElementAttackType = elementAttackType;
    }
    
    public bool InRange(Transform enemyPosition)
    {
        return enemyPosition.position.magnitude >= Range;
    }

    public void AttackRate(UnityAction<float> attackAction, float damage)
    {
        _fireRateTemp += Time.deltaTime;

        if (_fireRateTemp > _fireRate)
        {
            _fireRate += Time.deltaTime;
            attackAction?.Invoke(damage);
        }
    }
}