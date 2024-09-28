using UnityEngine;

public class BaseHealth : IDamageable
{
    private float _currentHealth;
    
    public BaseHealth(float currentHealth)
    {
        _currentHealth = currentHealth;
    }
    
    public void IncreaseHealth(float value)
    {
        _currentHealth += value;
    }

    public void Damage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth > 0) return;
        
        Die();
        _currentHealth = 0;
    }

    public void Die()
    {
        Debug.Log("Dead");
    }
}