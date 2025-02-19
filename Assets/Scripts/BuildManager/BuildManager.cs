﻿using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class BuildManager
{
    private CellManager _cellManager;
    private BuildObjectReceiver _buildObjectReceiver;
    private IInstantiator _instantiator;
    private GameCurrency _gameCurrency;
    
    private List<BuildCells> buildCells;
    
    [Inject]
    private void Construct(CellManager cellManager, IInstantiator instantiator, BuildObjectReceiver buildObjectReceiver,
        GameCurrency gameCurrency)
    {
        _cellManager = cellManager;
        _instantiator = instantiator;
        _buildObjectReceiver = buildObjectReceiver;
        _gameCurrency = gameCurrency;
    }
    
    public void BuildAction(Vector3 worldPos)
    {
        var mousePosCell = _cellManager.GetCellAtIndex(worldPos);
        
        if(mousePosCell == null) return;

        buildCells = new List<BuildCells>();
        
        _cellManager.GetXZ(worldPos,out var x, out var z);
        for (int i = 0; i < _buildObjectReceiver.CurrentGridEntitySO.X; i++)
        {
            for (int j = 0; j < _buildObjectReceiver.CurrentGridEntitySO.Z; j++)
            {
                if ( x + i >= 0 && z + j >= 0 && x + i < _cellManager.Width && z + j < _cellManager.Height)
                {
                    var buildCell = _cellManager.Grid[x + i, z + j].Slot;
                    if(buildCell.IsEntityActive == true || buildCell.IsFull == true) return;
                    
                    BuildCells buildableCells = new BuildCells(buildCell);
                    buildCells.Add(buildableCells);
                }
            }
        }
        
        if(_buildObjectReceiver.CurrentGridEntitySO.CanBuild(buildCells.Count))
            return;

        if(_gameCurrency.HasEnoughCoins(_buildObjectReceiver.CurrentGridEntitySO.BuildCost) == false)
            return;
        
        InstantiateSingleCell(buildCells).Forget();
    }

    private async UniTaskVoid InstantiateSingleCell(List<BuildCells> buildCells)
    {
        var induvialCellPower = _buildObjectReceiver.CurrentGridEntitySO.AttackPower /
                                _buildObjectReceiver.CurrentGridEntitySO.PowerSize;
        
        foreach (var cell in buildCells)
        {
            cell.Cell.IsEntityActive = true;
            cell.Cell.IsFull = true;
            cell.Cell.Power = induvialCellPower;
        }

        await UniTask.WaitForEndOfFrame();
        var tower = _instantiator.InstantiatePrefab(_buildObjectReceiver.CurrentGridEntitySO.BuildObject);
        tower.transform.position = SetMidPosMultipleCells();
        _gameCurrency.SpendCoins(_buildObjectReceiver.CurrentGridEntitySO.BuildCost);
    }
    
    private void InstantiateMultipleCells(List<BuildCells> buildCells)
    {
        foreach (var cell in buildCells)
        {
            cell.Cell.IsEntityActive = true;
            cell.Cell.IsFull = true;
            var tower = _instantiator.InstantiatePrefab(_buildObjectReceiver.CurrentGridEntitySO.BuildObject);
            tower.transform.position = cell.SpawnPosition * _cellManager.CellSize + _cellManager.OriginPosition + 
                                       new Vector3(_cellManager.CellSize / 2, 0, _cellManager.CellSize / 2);
        }
    }
    
    private Vector3 SetMidPosMultipleCells()
    {
        List<Vector3> cellsPosition = buildCells.Select(cell => 
            _cellManager.GetCellMidPointPositionXZ(cell.Cell.GridIndexX, cell.Cell.GridIndexZ)).ToList();

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

public struct BuildCells
{
    public Vector3 SpawnPosition;
    public Cell Cell;
        
    public BuildCells(Cell cell)
    {
        Cell = cell;
        SpawnPosition = new Vector3(cell.GridIndexX,0, cell.GridIndexZ);
    }
}