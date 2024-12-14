using UnityEngine;

public class CustomGizmos
{
    public bool CanDrawGizmos = false;
    protected Vector3 Center;

    protected CustomGizmos(Vector3 center)
    {
        Center = center;
    }
    
    public virtual void DrawGizmos(Color color)
    {
        if(CanDrawGizmos == false) return;
        Gizmos.color = color;
    }
}