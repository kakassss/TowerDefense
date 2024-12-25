using UnityEngine;

[System.Serializable]
public class BaseHealth : IDamageable
{
    public float GetCurrentHealth { get; private set; }
    
    public IDeath Death;
    public ElementType DefenseType;
    
    public BaseHealth(float currentHealth, ElementType defenseType)
    {
        GetCurrentHealth = currentHealth;
        DefenseType = defenseType;
    }
    
    public void IncreaseHealth(float value)
    {
        GetCurrentHealth += value;
    }

    public void Damage(float damageAmount, ElementType damageType)
    {
        if (DefenseType == damageType)
        {
            Debug.Log("Defense Activated");
        }
        
        GetCurrentHealth -= damageAmount;
        
        if (GetCurrentHealth > 0) return;
        
        Death.Death();
        GetCurrentHealth = 0;
    }
}