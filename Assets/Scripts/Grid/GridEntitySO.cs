using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GridEntitySO", fileName = "GridEntitySO")]
public class GridEntitySO : ScriptableObject
{
    public List<BaseObject> BaseObjects;
}

[Serializable]
public class BaseObject
{
    public string Name;
    
    public int X;
    public int Z;
    
    public GameObject BuildObject;
    public GhostObject GhostObject;
    
    public int BuildCost;
    [HideInInspector] public float PowerSize => X * Z;
    [Header("Power")] 
    public float AttackPower;
    
    public bool CanBuild(int buildSlotCount)
    {
        if (X == 1 && Z == 1 && buildSlotCount == 1)
        {
            return false;
        }
        
        return buildSlotCount != X + Z;
    }
}


[Serializable]
public class GhostObject
{
    public GameObject GhostGO;
}