using UnityEngine;

public class BaseEnemyDefence : IEnemyDefence
{
    public EnemyDefenceSO DefenceSo;
    
    public bool DefenceAction(int defenceValue,ElementType elementType)
    {
        if (DefenceSo.FireDefence <= defenceValue 
            && elementType == DefenceSo.DefenceType) return false;
        
        Debug.Log("Observed");
        return true;
    }
}