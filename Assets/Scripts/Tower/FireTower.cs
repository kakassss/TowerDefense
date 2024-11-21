using System;
using UnityEngine;

public class FireTower : BaseTower
{
    [SerializeField] protected SphereCollider triggerCollider;

    protected override void SetTowerStats()
    {
        base.SetTowerStats();
        triggerCollider.radius = _towerAttackSo.Range;
    }

    // private void Update()
    // {
    //     AttackAction();
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out IEnemy enemy)) return;
        
        _enemies.Add(enemy);
        Debug.Log("Enemy added");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out IEnemy enemy)) return;
        
        _enemies.Remove(enemy);
        Debug.Log("Enemy removed");
    }
}