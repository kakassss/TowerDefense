public class BaseEnemy
{
    public int MovementSpeed;
    public int Damage;

    public int HitRate;
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

public class Enemy
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