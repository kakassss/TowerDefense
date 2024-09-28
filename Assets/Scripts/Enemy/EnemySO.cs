using UnityEngine;

[CreateAssetMenu(menuName = "EnemySO/EnemyDefence",fileName = "EnemyDefence")]
public class EnemySO : ScriptableObject
{
    [Header("Prefabs")] 
    public GameObject Prefab;


    [Header("AttackStats")] 
    public AttackType AttackType;
    public int AttackPower;
    
    
    
    [Header("DefenceStats")] 
    public ElementType DefenceType;
    public int FireDefence;
    public int IceDefence;
    public int LightDefence;
    public int DarkDefence;
}