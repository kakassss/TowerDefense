using UnityEngine;

public class DrawSphereGizmos : CustomGizmos
{
    public DrawSphereGizmos(Vector3 center) : base(center)
    {
    }

    public override void DrawGizmos(Color color)
    {
        base.DrawGizmos(color);
        Gizmos.DrawSphere(Center,1f);
    }
}