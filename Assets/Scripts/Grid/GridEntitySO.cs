﻿using System;
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
    
    
    public List<Material> GreenMaterials;
    public List<Material> RedMaterials;
    private List<MeshRenderer> MeshRenderers;

    public List<MeshRenderer> GetMeshRenderers()
    {
        MeshRenderers = new List<MeshRenderer>();
        
        for (int i = 0; i < GhostGO.transform.childCount; i++)
        {
            var child = GhostGO.transform.GetChild(i);
            MeshRenderers.Add(child.GetComponent<MeshRenderer>());
        }

        return MeshRenderers;
    }
}

public class GhostObjectReceiver
{
    private Action OnGhostMaterialGreen;
    private Action OnGhostMaterialRed;
    
    public GameObject GameObject;
    public int GridIndexX;
    public int GridIndexZ;


    public List<MeshRenderer> MeshRenderers;
    public List<Material> GreenMaterials;
    public List<Material> RedMaterials;
    
    public void OnGhostMaterialGreenFire()
    {
        OnGhostMaterialGreen?.Invoke();
    }

    public void AddOnGhostMaterialGreen(Action action)
    {
        OnGhostMaterialGreen += action;
    }

    public void RemoveOnGhostMaterialGreen(Action action)
    {
        OnGhostMaterialGreen -= action;
    }
    
    public void OnGhostMaterialRedFire()
    {
        OnGhostMaterialRed?.Invoke();
    }

    public void AddOnGhostMaterialRed(Action action)
    {
        OnGhostMaterialRed += action;
    }

    public void RemoveOnGhostMaterialRed(Action action)
    {
        OnGhostMaterialRed -= action;
    }
    
    
}