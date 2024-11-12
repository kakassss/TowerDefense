using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildManager
{
    private CellManager _cellManager;
    private GridEntitySO _gridEntitySo;
    private IInstantiator _instantiator;
    
    [Inject]
    private void Construct(CellManager cellManager,GridEntitySO gridEntitySo, IInstantiator instantiator)
    {
        _cellManager = cellManager;
        _gridEntitySo = gridEntitySo;
        _instantiator = instantiator;
    }
    
    public void BuildAction(Vector3 worldPos)
    {
        var mousePosCell = _cellManager.GetCellAtIndex(worldPos);
        
        if(mousePosCell == null) return;

        List<BuildMultipleCells> buildCells = new List<BuildMultipleCells>();
        
        _cellManager.GetXZ(worldPos,out var x, out var z);
        
        for (int i = 0; i < _gridEntitySo.X; i++)
        {
            for (int j = 0; j < _gridEntitySo.Z; j++)
            {
                if ( x + i >= 0 && z + j >= 0 && x + i < _cellManager.Width && z + j < _cellManager.Height)
                {
                    var buildCell = _cellManager.Grid[x + i, z + j];
                    if(buildCell.Slot.IsFull == true) return;
                
                    BuildMultipleCells buildableMultipleCells = new BuildMultipleCells(buildCell,_gridEntitySo.BuildObject);
                    buildCells.Add(buildableMultipleCells);
                }
            }
        }
        
        if(buildCells.Count <= 0) return;
        
        InstantiateAction(buildCells);    
    }

    private void InstantiateAction(List<BuildMultipleCells> buildCells)
    {
        foreach (var cell in buildCells)
        {
            cell.Cell.Slot.IsFull = true;
            var tower = _instantiator.InstantiatePrefab(cell.BuildObject);
            tower.transform.position = cell.SpawnPosition * _cellManager.CellSize + _cellManager.OriginPosition + 
                                       new Vector3(_cellManager.CellSize / 2, 0, _cellManager.CellSize / 2);
        }
    }
}

public struct BuildMultipleCells
{
    public GameObject BuildObject;
        
    public Vector3 SpawnPosition;
    public Grid<Cell<GameObject>> Cell;
        
    public BuildMultipleCells(Grid<Cell<GameObject>> cell,GameObject gameObject)
    {
        Cell = cell;
        BuildObject = gameObject;
            
        SpawnPosition = new Vector3(cell.Slot.GridIndexX,0, cell.Slot.GridIndexZ);
    }
}