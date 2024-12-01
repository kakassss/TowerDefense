using System;
using UnityEngine;

public class UnityBounds : MonoBehaviour
{
    private Bounds bounds;
    [SerializeField] BoxCollider boxCollider;
    
    
    [SerializeField] private float boundSizeX = 25f;
    [SerializeField] private float boundSizeZ = 25f;
    private void OnValidate()
    {
        bounds = new Bounds(transform.position, new Vector3(boundSizeX,1,boundSizeZ));
        boxCollider.size = bounds.size;
        
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}


public class DetectedEnemies
{
    
    
    
}