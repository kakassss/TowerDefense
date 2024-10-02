using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeTrigger : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    
    private BaseTowerAttack _towerAttack;

    private List<IEnemy> _inRangeEnemies;

    private void Start()
    {
        _towerAttack = new BaseTowerAttack(5, 7, 1, ElementType.Dark);
        
        FindEnemies();
    }

    private void FindEnemies()
    {
        _inRangeEnemies = new List<IEnemy>();
        
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_towerAttack.InRange(_enemies[i].transform))
            {
                _inRangeEnemies.Add(_enemies[i]);
            }
        }
        
        Debug.Log("Tower has targeted " + _inRangeEnemies.Count + " enemies");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,7);
    }
}
