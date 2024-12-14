using UnityEngine;

[System.Serializable] // Using for bool
public class DrawCubeGizmos : CustomGizmos
{
    public DrawCubeGizmos(Vector3 center) : base(center)
    {
    }

    public override void DrawGizmos(Color color)
    {
        base.DrawGizmos(color);
        Gizmos.DrawCube(Center,Vector3.one);
    }
}