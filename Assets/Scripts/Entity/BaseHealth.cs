
[System.Serializable]
public class BaseHealth : IDamageable
{
    public float GetCurrentHealth { get; private set; }

    public IDeath Death;

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
        
        Death.Death();
        GetCurrentHealth = 0;
    }
}