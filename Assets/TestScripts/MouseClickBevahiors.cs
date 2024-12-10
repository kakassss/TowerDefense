using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MouseClickBevahiors : MonoBehaviour
{
    private Utils _utils;
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;

    private Grid<Cell> mouseCell;
    List<Cell> buildableCells;

    [Inject]
    private void Construct(Utils utils,GhostObjectReceiver ghostObjectReceiver,CellManager cellManager)
    {
        _utils = utils;
        _ghostObjectReceiver = ghostObjectReceiver;
        _cellManager = cellManager;
    }
    
    private void Update() // UPdatede yapacagımıza current grid tutup, o variableın değeri değiştikce bunu sorgulatabiliriz?
    {
        transform.position = _utils.GetValidPositionWithLayerMask(); // mavi küp için sonradan kaldırabilir
        if(_ghostObjectReceiver.GameObject == null) return;
        mouseCell = _cellManager.GetCellAtIndex(_utils.GetValidPositionWithLayerMask());

        if (mouseCell != null)
        {
            CalculateGridPos();
            return;
        }
        
        _ghostObjectReceiver.GameObject.transform.position = transform.position;
        _ghostObjectReceiver.OnGhostMaterialRedFire();
        //_cellManager.GetXZ(_utils.GetValidPositionWithLayerMask(),out var X, out var Z);
        //_cellManager.GetWorldPosition(X, Z);
    }

    private void CalculateGridPos()
    {
        _cellManager.GetXZ(_utils.GetValidPositionWithLayerMask(),out var x, out var z);

        buildableCells = new List<Cell>();

        for (int i = 0; i < _ghostObjectReceiver.GridIndexX; i++) // object grid size for x
        {
            for (int j = 0; j < _ghostObjectReceiver.GridIndexZ; j++) // object grid size for z
            {
                if ( x + i >= 0 && z + j >= 0 && x + i < _cellManager.Width && z + j < _cellManager.Height)
                {
                    var buildCell = _cellManager.Grid[x + i, z + j].Slot;
                    buildableCells.Add(buildCell);
                    if (buildCell.IsFull)
                    {
                        _ghostObjectReceiver.OnGhostMaterialRedFire();
                        SetMidPosOnGrid(x,z,_ghostObjectReceiver.GhostObjectBuildType());
                        return;
                    }
                    
                    _ghostObjectReceiver.OnGhostMaterialGreenFire();
                }
                else
                {
                    _ghostObjectReceiver.OnGhostMaterialRedFire(); // if there is a cell on out of border position
                }
            }
        }

        SetMidPosMultipleGrid();
    }
    
    // get current cells position and calculate ghost position just for one cells
    // If there is a full grid, cant calculate position
    // BuildType: avoid to 1x1 ghost position fix
    private void SetMidPosOnGrid(int x, int z, bool buildType)
    {
        Vector3 crossMouseGrid = buildType ? _cellManager.GetCellMidPointPositionXZ(x + 1, z + 1) 
            : _cellManager.GetCellMidPointPositionXZ(x, z);
        var onMouseGridPos = _cellManager.GetCellMidPointPosition(_utils.GetValidPositionWithLayerMask());
        
        _ghostObjectReceiver.GameObject.transform.position = new Vector3(
            (onMouseGridPos.x + crossMouseGrid.x) / 2, 0,
            (onMouseGridPos.z + crossMouseGrid.z) / 2);
    }
        
    private void SetMidPosMultipleGrid()
    {
        List<Vector3> cellsPosition = buildableCells.Select(cell => _cellManager.GetCellMidPointPositionXZ(cell.GridIndexX, cell.GridIndexZ)).ToList();

        Vector3 averageX = Vector3.zero;
        Vector3 averageZ = Vector3.zero;

        foreach (var pos in cellsPosition)
        {
            averageX += new Vector3(pos.x,0,0);
            averageZ += new Vector3(0, 0, pos.z);
        }
        _ghostObjectReceiver.GameObject.transform.position = new Vector3(averageX.x / cellsPosition.Count, 0, averageZ.z / cellsPosition.Count);
    }
}