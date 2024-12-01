using UnityEngine;

[System.Serializable]
public class BaseHealth : IDamageable
{
    public float GetCurrentHealth { get; private set; }

    public BaseHealth(float currentHealth)
    {
        GetCurrentHealth = currentHealth;
    }
    
    public void IncreaseHealth(float value)
    {
        GetCurrentHealth += value;
    }

    public void Damage(float value)
    {
        GetCurrentHealth -= value;
        
        if (GetCurrentHealth > 0) return;
        
        Die();
        GetCurrentHealth = 0;
    }
    
    private void Die()
    {
        Debug.Log("Dead");
    }
}