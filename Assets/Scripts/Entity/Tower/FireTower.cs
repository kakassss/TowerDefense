using UnityEngine;

public class FireTower : BaseTower
{
    protected override void SetTowerStats()
    {
        base.SetTowerStats();
    }

    private void Update()
    {
        AttackAction();
    }
}