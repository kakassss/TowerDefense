using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseHealth : IDamageable
{
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }
    
    public IDeath Death;
    public ElementType DefenseType;
    public int HealthStage = 1;
    public bool Upgradeable;

    public Action OnHealthUpgradeFinish;
    
    //Using multiple health stages
    public BaseHealth(Dictionary<int,int> healthStages, ElementType defenseType)
    {
        MaxHealth = healthStages[HealthStage];
        CurrentHealth = healthStages[HealthStage];
        Upgradeable = true;
        DefenseType = defenseType;
    }
    
    //Using one static health
    public BaseHealth(float maxHealth, ElementType defenseType)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Upgradeable = false;
        DefenseType = defenseType;
    }
    
    
    public void IncreaseHealthStage(Dictionary<int,int> healthStages)
    {
        if (healthStages.Count <= HealthStage)
        {
            Upgradeable = false;
            OnHealthUpgradeFinish?.Invoke();
            return;
        }
        
        HealthStage++;
        
        MaxHealth = healthStages[HealthStage];
        CurrentHealth = healthStages[HealthStage];
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