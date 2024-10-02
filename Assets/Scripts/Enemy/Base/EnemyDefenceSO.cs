using UnityEngine;

[CreateAssetMenu(menuName = "EnemySO/EnemyDefence",fileName = "EnemyDefence")]
public class EnemyDefenceSO : ScriptableObject
{
    [Header("DefenceStats")] 
    public ElementType DefenceType;
    public int FireDefence;
    public int IceDefence;
    public int LightDefence;
    public int DarkDefence;
}

[CreateAssetMenu(menuName = "EnemySO/EnemyAttack",fileName = "EnemyAttack")]
public class EnemyAttackSO : ScriptableObject
{
    [Header("AttackStats")] 
    public AttackType AttackType;
    public ElementType AttackElement;
    public int AttackPower;
    public int Range;
    public int FireRate;
}

[CreateAssetMenu(menuName = "EnemySO/EnemyGameObject",fileName = "EnemyGameObject")]
public class EnemyGameObjectSO : ScriptableObject
{
    [Header("Prefabs")] 
    public GameObject Prefab;
}