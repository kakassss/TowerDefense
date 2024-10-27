using UnityEngine;
using Zenject;

public class GridController : MonoBehaviour
{
    private CellManager _cellManager;

    [Inject]
    private void Construct(CellManager cellManager)
    {
        _cellManager = cellManager;
    }
    
    
    private void OnDrawGizmos()
    {
        if(Application.isPlaying == false) return;
        
        Gizmos.color = Color.red;
        
        for (int i = 0; i < _cellManager.Width; i++)
        {
            for (int j = 0; j < _cellManager.Height; j++)
            {
                Gizmos.DrawLine(
                    _cellManager.GetWorldPosition(j, i),
                    _cellManager.GetWorldPosition(j + 1, i));

                Gizmos.DrawLine(
                    _cellManager.GetWorldPosition(j, i + 1),
                    _cellManager.GetWorldPosition(j,i));   
            }
        }

        Gizmos.DrawLine(
            _cellManager.GetWorldPosition(0, _cellManager.Height),
            _cellManager.GetWorldPosition(_cellManager.Width, _cellManager.Height));
        
        Gizmos.DrawLine(
            _cellManager.GetWorldPosition(_cellManager.Width,0),
            _cellManager.GetWorldPosition(_cellManager.Width, _cellManager.Height));
    }
    

}