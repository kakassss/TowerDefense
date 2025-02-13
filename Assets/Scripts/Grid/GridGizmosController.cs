using Sirenix.OdinInspector;
using UnityEngine;

public class GridGizmosController : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GridSOData _gridData;

    [InfoBox("You can use after changing gizmos object transform position")]
    [Button("Calculate Grid Gizmos", ButtonSizes.Medium, ButtonStyle.Box)]
    private void OnValidate()
    {

    }
    
    private void OnDrawGizmos()
    {
        //if(Application.isPlaying == false) return;
        
        if(_gridData == null) return;
        
        Gizmos.color = Color.red;
        //_gridData.GridOriginPosition.x = -(_gridData.GridSize * _gridData.CellSize) / 2 + transform.position.x;
        //_gridData.GridOriginPosition.y = 0.1f;
        //_gridData.GridOriginPosition.z = -(_gridData.GridSize * _gridData.CellSize) / 2 + transform.position.z;
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