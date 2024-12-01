using UnityEngine;

public class FireTower : BaseTower
{
    [SerializeField] protected SphereCollider triggerCollider;

    protected override void SetTowerStats()
    {
        base.SetTowerStats();
        triggerCollider.radius = _towerAttackSo.Range;
    }

    private void Update()
    {
        AttackAction();
    }
    
}