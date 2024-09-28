using UnityEngine;

public class BaseEnemyDefence : IEnemyDefence
{
    public EnemySO _so;
    
    public bool DefenceAction(int defenceValue,ElementType elementType)
    {
        if (_so.FireDefence <= defenceValue 
            && elementType == _so.DefenceType) return false;
        
        Debug.Log("Observed");
        return true;
    }
}