using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildManager
{
    private CellManager _cellManager;
    private BuildSelectManager _buildSelectManager;
    private IInstantiator _instantiator;
    
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

        List<BuildMultipleCells> buildCells = new List<BuildMultipleCells>();
        
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
        
        InstantiateMultipleCells(buildCells);    
    }

    private void InstantiateSingleCell(List<BuildMultipleCells> buildCells)
    {
        
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