﻿using UnityEngine;

// Şimdilik test class'ı olarak kalabilir veya ileri de tekrar bu modele dönülebilir
// IEnemy interfaceınden daha iyi yaralanabilmek için monobehavior olan bir class'a eklendi
public class BaseEnemy : IEnemy
{
    public BaseHealth Health { get; }
    public BaseEnemyDefence Defence { get; }
    public BaseEnemyAttack Attack { get; }
    
    public BaseEnemy(EnemyDefenceSO enemyDefenceSo, EnemyAttackSO enemyAttackSo)
    {
        Defence = new BaseEnemyDefence
        {
            DefenceSo = enemyDefenceSo
        };
        Attack = new BaseEnemyAttack(enemyAttackSo);
        Health = new BaseHealth(100);
    }
}