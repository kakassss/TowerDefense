using UnityEngine;

public class CustomGizmos
{
    protected Vector3 Center;

    protected CustomGizmos(Vector3 center)
    {
        Center = center;
    }
    
    public virtual void DrawGizmos(Color color)
    {
        Gizmos.color = color;
    }
}