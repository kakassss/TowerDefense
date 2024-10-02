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