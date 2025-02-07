using UnityEngine;

public class BaseEnemyHealth : IDamageable
{
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }
    
    public IDeath Death;
    public ElementType DefenseType;
    
    //Using one static health
    public BaseEnemyHealth(float maxHealth, ElementType defenseType)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        DefenseType = defenseType;
    }
    
    public void IncreaseHealth(float value)
    {
        MaxHealth += value;
        CurrentHealth += value;
    }

    public void Damage(float damageAmount, ElementType damageType)
    {
        if (DefenseType == damageType)
        {
            Debug.Log("Defense Activated");
        }
        
        CurrentHealth -= damageAmount;
        if (CurrentHealth > 0) return;
        
        Death.Death();
        CurrentHealth = 0;
    }
}