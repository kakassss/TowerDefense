using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GridEntitySO", fileName = "GridEntitySO")]
public class GridEntitySO : ScriptableObject
{
    public int X;
    public int Z;

    public Vector3 Size;
    
    public GameObject BuildObject;
    public GhostObject GhostObject;
}

[Serializable]
public class GhostObject
{
    public GameObject GhostGO;
}