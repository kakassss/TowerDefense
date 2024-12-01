using UnityEngine;

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