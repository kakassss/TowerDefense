using UnityEngine;

public class GoblinEnemy : IEnemy
{
    public BaseHealth Health => new(100);
    public BaseEnemyDefence Defence { get; }
    public GameObject Prefab;
    
    
    public GoblinEnemy(EnemySO enemySo)
    {
        Defence = new BaseEnemyDefence
        {
            _so = enemySo
        };
    }
}