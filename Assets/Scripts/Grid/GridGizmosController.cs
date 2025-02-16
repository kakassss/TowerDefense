using UnityEngine;

public class GridGizmosController : MonoBehaviour
{
    [SerializeField] private GridSOData _gridData;

    private void OnDrawGizmos()
    {
        if(_gridData == null) return;
        
        Gizmos.color = Color.red;
        
        for (int i = 0; i < _gridData.Width; i++)
        {
            for (int j = 0; j < _gridData.Height; j++)
            {
                Gizmos.DrawCube(
                    GetWorldPosition(j, i) + new Vector3(0,0.2f,0), new Vector3(0.5f,0.5f,0.5f));
        
                Gizmos.DrawCube(
                    GetWorldPosition(j, i + 1) + new Vector3(0,0.2f,0), new Vector3(0.5f,0.5f,0.5f));   
            }
        }
        
        for (int i = 0; i < _gridData.Width; i++)
        {
            for (int j = 0; j < _gridData.Height; j++)
            {
                Gizmos.DrawLine(
                    GetWorldPosition(j, i) + new Vector3(0,0.2f,0), 
                    GetWorldPosition(j + 1, i) + new Vector3(0,0.2f,0));
        
                Gizmos.DrawLine(
                    GetWorldPosition(j, i + 1) + new Vector3(0,0.2f,0),
                    GetWorldPosition(j,i) + new Vector3(0,0.2f,0));   
            }
        }
        
        Gizmos.DrawLine(
            GetWorldPosition(0, _gridData.Height),
            GetWorldPosition(_gridData.Width, _gridData.Height));
        
        Gizmos.DrawLine(
            GetWorldPosition(_gridData.Width,0),
            GetWorldPosition(_gridData.Width, _gridData.Height));
    }
    
    private Vector3 GetWorldPosition(int x, int z)
    {
        return (new Vector3(x, 0, z) * _gridData.CellSize + _gridData.OriginPosition);
    }

}