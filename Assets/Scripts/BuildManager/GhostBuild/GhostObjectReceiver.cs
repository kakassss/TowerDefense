using System;
using UnityEngine;

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