using UnityEngine;

public class FireTowerAttack: ITowerAttack, ITowerUpgrade
{
    [Header("TowerData")]
    private BaseTowerAttack _baseTowerAttack;
    private ElementType _attackType;
    
    [Header("EnemyData")]
    private Transform _enemyPosition;
    private IEnemy _enemy;
     
    
    public FireTowerAttack()
    {
        _baseTowerAttack = new BaseTowerAttack(15,5,1,ElementType.Fire);
    }
    
    public void Attack(int damage)
    {
        if (_baseTowerAttack.InRange(_enemyPosition) == false) return;
        if(_enemy.Defence.DefenceAction(_baseTowerAttack.Damage,_baseTowerAttack.ElementAttackType) == false) return; 
        
        _baseTowerAttack.AttackRate(_enemy.Health.Damage,_baseTowerAttack.Damage);
    }

    public void Upgrade(BaseTowerAttack towerAttack)
    {
        towerAttack.Damage += 10;
        towerAttack.Range += 5;
        //Save?
    }
}