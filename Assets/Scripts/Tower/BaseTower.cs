using UnityEngine;

//used for uncompleted save system prototype
public class BaseTower : MonoBehaviour, ITower
{
    public BaseTowerAttack Attack { get; }
    public BaseHealth Health { get; }
}