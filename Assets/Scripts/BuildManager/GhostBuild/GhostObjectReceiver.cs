using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class GhostObjectReceiver
{
    private Action OnGhostMaterialGreen;
    private Action OnGhostMaterialRed;
    
    public GameObject GameObject;
    public int GridIndexX;
    public int GridIndexZ;
    
    public bool GhostObjectValid;
    public bool GhostObjectBuildType()
    {
        return GridIndexX + GridIndexZ > 2;
    }
    
    public void ResetGhostObject()
    {
        GhostObjectValid = false;
        GridIndexX = 0;
        GridIndexZ = 0;
        
        //GameObject.transform.position = Vector3.zero;

        Object.Destroy(GameObject);
        GameObject = null;
    }
    
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