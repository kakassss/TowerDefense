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
        return enemyPosition.position.magnitude <= Range;
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

public class Tower
{
    public int AttackValue;
    
    private IEnemyDefence _currentTarget;
    
    public void Attack()
    {
        _currentTarget.DefenceAction(AttackValue,ElementType.Dark);
    }
}

public class Enemyxd
{
    public void Defence(IEnemyDefence defence)
    {
        defence.DefenceAction(15,ElementType.Fire);
    }
}

public class BaseEnemyAttackStats
{
    public int FireDamage;
    public int IceDamage;
    public int LightDamage;
    public int DarkDamage;

    public BaseEnemyAttackStats(
        int fireDamage, int iceDamage,
        int lightDamage, int darkDamage)
    {
        FireDamage = fireDamage;
        IceDamage = iceDamage;
        LightDamage = lightDamage;
        DarkDamage = darkDamage;
    }
}