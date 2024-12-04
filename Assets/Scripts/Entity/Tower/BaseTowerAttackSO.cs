using UnityEngine;

[CreateAssetMenu(menuName = "TowerSO/TowerAttack",fileName = "TowerAttack")]
public class BaseTowerAttackSO : ScriptableObject
{
    [Header("Attack")]
    public ElementType ElementType;
    public float Damage;
    public float Range;
    public float FireRate;
    
    [Header("RotateAnimation")]
    public float RotateSpeed;
}
