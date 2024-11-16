using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class BuildManager
{
    private CellManager _cellManager;
    private BuildSelectManager _buildSelectManager;
    private IInstantiator _instantiator;
    
    private List<BuildMultipleCells> buildCells;
    
    [Inject]
    private void Construct(CellManager cellManager, IInstantiator instantiator, BuildSelectManager buildSelectManager)
    {
        _cellManager = cellManager;
        _instantiator = instantiator;
        _buildSelectManager = buildSelectManager;
    }
    
    public void BuildAction(Vector3 worldPos)
    {
        var mousePosCell = _cellManager.GetCellAtIndex(worldPos);
        
        if(mousePosCell == null) return;

        buildCells = new List<BuildMultipleCells>();
        
        _cellManager.GetXZ(worldPos,out var x, out var z);
        
        for (int i = 0; i < _buildSelectManager.CurrentGridEntitySO.X; i++)
        {
            for (int j = 0; j < _buildSelectManager.CurrentGridEntitySO.Z; j++)
            {
                if ( x + i >= 0 && z + j >= 0 && x + i < _cellManager.Width && z + j < _cellManager.Height)
                {
                    var buildCell = _cellManager.Grid[x + i, z + j];
                    if(buildCell.Slot.IsFull == true) return;
                
                    BuildMultipleCells buildableMultipleCells = new BuildMultipleCells(buildCell);
                    buildCells.Add(buildableMultipleCells);
                }
            }
        }
        
        if(buildCells.Count != _buildSelectManager.CurrentGridEntitySO.X + _buildSelectManager.CurrentGridEntitySO.Z)
            return;


        InstantiateSingleCell(buildCells);
        //InstantiateMultipleCells(buildCells);    
    }

    private void InstantiateSingleCell(List<BuildMultipleCells> buildCells)
    {
        foreach (var cell in buildCells)
        {
            cell.Cell.Slot.IsFull = true;
        }
        var tower = _instantiator.InstantiatePrefab(_buildSelectManager.CurrentGridEntitySO.BuildObject);
        tower.transform.position = SetMidPosMultipleCells();
    }
    
    private void InstantiateMultipleCells(List<BuildMultipleCells> buildCells)
    {
        foreach (var cell in buildCells)
        {
            cell.Cell.Slot.IsFull = true;
            var tower = _instantiator.InstantiatePrefab(_buildSelectManager.CurrentGridEntitySO.BuildObject);
            tower.transform.position = cell.SpawnPosition * _cellManager.CellSize + _cellManager.OriginPosition + 
                                       new Vector3(_cellManager.CellSize / 2, 0, _cellManager.CellSize / 2);
        }
    }
    
    public Vector3 SetMidPosMultipleCells()
    {
        List<Vector3> cellsPosition = buildCells.Select(cell => 
            _cellManager.GetCellMidPointPositionXZ(cell.Cell.Slot.GridIndexX, cell.Cell.Slot.GridIndexZ)).ToList();

        Vector3 averageX = Vector3.zero;
        Vector3 averageZ = Vector3.zero;

        foreach (var pos in cellsPosition)
        {
            averageX += new Vector3(pos.x,0,0);
            averageZ += new Vector3(0, 0, pos.z);
        }

        return new Vector3(averageX.x / cellsPosition.Count, 0, averageZ.z / cellsPosition.Count);
    }
}

public struct BuildMultipleCells
{
    public Vector3 SpawnPosition;
    public Grid<Cell<GameObject>> Cell;
        
    public BuildMultipleCells(Grid<Cell<GameObject>> cell)
    {
        Cell = cell;
        SpawnPosition = new Vector3(cell.Slot.GridIndexX,0, cell.Slot.GridIndexZ);
    }
}