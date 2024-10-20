using UnityEngine;
using Zenject;

public class TowerAttackManager : MonoBehaviour
{
    private TowerManager _towerManager;

    [Inject]
    private void Construct(TowerManager towerManager)
    {
        _towerManager = towerManager;
    }
    
    private void Update()
    {
        foreach (var tower in _towerManager.GetAttackerTowers())
        {
            tower.AttackAction();
        }
    }
}
