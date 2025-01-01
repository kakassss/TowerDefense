using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseGhostBuildState : MouseClickBaseState
{
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;

    private Grid<Cell> _mouseCell;
    private List<Cell> _buildableCells = new List<Cell>();
    private HashSet<Cell> _cellsSet = new HashSet<Cell>();
    
    private BuildingInputReader _buildingInputReader;
    private MouseClickStateEvents _mouseClickStateEvents;
    
    private Vector3 _midPosition;
    private float _midPosOffset = 3f;
    private (int x, int z) XZTuple;
    
    public MouseGhostBuildState(MouseClickStateMachine mouseClickStateMachine, GhostObjectReceiver ghostObjectReceiver, CellManager cellManager,
        BuildingInputReader buildingInputReader, MouseClickStateEvents mouseClickStateEvents)
        : base(mouseClickStateMachine)
    {
        _ghostObjectReceiver = ghostObjectReceiver;
        _cellManager = cellManager;
        _buildingInputReader = buildingInputReader;
        _mouseClickStateEvents = mouseClickStateEvents;
    }

    public override void OnEnter()
    {
        _mouseClickStateEvents.OnTowerBuildRelease += OnTowerBuildRelease;
        _buildingInputReader.Enable();
        //Debug.Log("dettü strangingü fayv years anniversary");
        //UI elementlerini açabilirsin
        //_mouseClickStateMachine.transform.position = _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask();
    }
    
    public override void OnUpdate(float deltaTime)
    {
        BuildAction();
    }

    public override void OnExit()
    {
        _mouseClickStateEvents.OnTowerBuildRelease -= OnTowerBuildRelease;
        _buildingInputReader.Disable();

        _ghostObjectReceiver.ResetGhostObject();
        //UI elementlerini kapatabilirsin
    }

    private void BuildAction()
    {
        _mouseClickStateMachine.transform.position = _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(); // mavi küp için sonradan kaldırabilir
        if(_ghostObjectReceiver.GameObject == null) return;
        _mouseCell = _cellManager.GetCellAtIndex(_mouseClickStateMachine.Utils.GetValidPositionWithLayerMask());

        if (_mouseCell != null)
        {
            CalculateGridPos();
            return;
        }
        
        _ghostObjectReceiver.GameObject.transform.position = _mouseClickStateMachine.transform.position;
        _ghostObjectReceiver.OnGhostMaterialRedFire();
        //_cellManager.GetXZ(_utils.GetValidPositionWithLayerMask(),out var X, out var Z);
        //_cellManager.GetWorldPosition(X, Z);
    }
    
    private void CalculateGridPos()
    {
        if (_buildableCells != null)
        {
            if (Vector3.Distance(_midPosition, _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask()) <=
                _midPosOffset)
            {
                _ghostObjectReceiver.GameObject.transform.position = _midPosition;
                //Debug.Log("onur xd " + Vector3.Distance(_midPosition, _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask()));
            }
            else
            {
                CalculateGridPos();
            }
        }
        else
        {
            CalculateGridPos();
        }

        void CalculateGridPos()
        {
            XZTuple = _cellManager.GetXZ(_mouseClickStateMachine.Utils.GetValidPositionWithLayerMask());

            _buildableCells.Clear();
            _cellsSet.Clear();

            for (int i = 0; i < _ghostObjectReceiver.GridIndexX; i++) // object grid size for x
            {
                for (int j = 0; j < _ghostObjectReceiver.GridIndexZ; j++) // object grid size for z
                {
                    
                    if ( XZTuple.x + i >= 0 && XZTuple.z + j >= 0 && XZTuple.x + i < _cellManager.Width && XZTuple.z + j < _cellManager.Height)
                    {
                        var buildCell = _cellManager.Grid[XZTuple.x + i, XZTuple.z + j].Slot;
                        _buildableCells.Add(buildCell);
                        if (buildCell.IsFull)
                        {
                            _ghostObjectReceiver.OnGhostMaterialRedFire();
                            SetMidPosOnGrid(XZTuple.x,XZTuple.z,_ghostObjectReceiver.GhostObjectBuildType());
                            return;
                        }
                        _ghostObjectReceiver.OnGhostMaterialGreenFire();
                    }
                    //UP-Right Corner
                    else if (XZTuple.z + j > _cellManager.Height -1 && XZTuple.x + i > _cellManager.Width -1)
                    {
                        var cell1 = _buildableCells[0];
                        var cell2 = _cellManager.Grid[cell1.GridIndexX - 1, cell1.GridIndexZ - 1].Slot;
                        var cell3 = _cellManager.Grid[cell1.GridIndexX, cell1.GridIndexZ - 1].Slot;
                        var cell4 = _cellManager.Grid[cell1.GridIndexX - 1, cell1.GridIndexZ].Slot;

                        _buildableCells.Add(cell2);
                        _buildableCells.Add(cell3);
                        _buildableCells.Add(cell4);
                    }
                    //UP-Left Corner
                    else if (XZTuple.z + j > _cellManager.Height -1 && XZTuple.x + i < _cellManager.Width -1)
                    {
                        var cell1 = _buildableCells[0];
                        var cell3 = _cellManager.Grid[cell1.GridIndexX, cell1.GridIndexZ -1].Slot;
                        var cell4 = _cellManager.Grid[cell3.GridIndexX +1, cell3.GridIndexZ].Slot;

                        _buildableCells.Add(cell3);
                        _buildableCells.Add(cell4);
                    }
                    //DOWN-Right Corner
                    else if (XZTuple.x + i > _cellManager.Width - 1 && XZTuple.z + j < _cellManager.Height - 1 )
                    {
                        var cell1 = _buildableCells[0];
                        var cell3 = _cellManager.Grid[cell1.GridIndexX -1, cell1.GridIndexZ].Slot;
                        var cell4 = _cellManager.Grid[cell1.GridIndexX - 1, cell1.GridIndexZ + 1].Slot;

                        _buildableCells.Add(cell3);
                        _buildableCells.Add(cell4);
                    }
                    else
                    {
                        _ghostObjectReceiver.OnGhostMaterialRedFire(); // if there is a cell on out of border position
                    }
                }
            }
            _cellsSet = _buildableCells.ToHashSet();
            Debug.Log("asdasd " + _cellsSet.Count);
            foreach (var cell in _cellsSet)
            {
                Debug.Log("sadasd " + cell.GridIndexX + " " + cell.GridIndexZ);
            }
            
            if (_buildableCells.Count != 2 && _buildableCells.Count != 1)
            {
                SetMidPosMultipleGrid();
                _ghostObjectReceiver.GameObject.transform.position = _midPosition;
            }
        }
        
        
        //Set Ghost object position, if there is non full cells
        
    }
    
    // get current cells position and calculate ghost position just for one cells
    // If there is a full grid, cant calculate position
    // BuildType: avoid to 1x1 ghost position fix
    private void SetMidPosOnGrid(int x, int z, bool buildType)
    {
        Vector3 crossMouseGrid = buildType ? _cellManager.GetCellMidPointPositionXZ(x + 1, z + 1) 
            : _cellManager.GetCellMidPointPositionXZ(x, z);
        var onMouseGridPos = _cellManager.GetCellMidPointPosition(_mouseClickStateMachine.Utils.GetValidPositionWithLayerMask());
        
        _ghostObjectReceiver.GameObject.transform.position = new Vector3(
            (onMouseGridPos.x + crossMouseGrid.x) / 2, 0,
            (onMouseGridPos.z + crossMouseGrid.z) / 2);
    }
        
    private void SetMidPosMultipleGrid()
    {
        List<Vector3> cellsPosition = _cellsSet.Select(cell => _cellManager.GetCellMidPointPositionXZ(cell.GridIndexX, cell.GridIndexZ)).ToList();

        Vector3 averageX = Vector3.zero;
        Vector3 averageZ = Vector3.zero;

        foreach (var pos in cellsPosition)
        {
            averageX += new Vector3(pos.x,0,0);
            averageZ += new Vector3(0, 0, pos.z);
        }
        //_ghostObjectReceiver.GameObject.transform.position = new Vector3(averageX.x / cellsPosition.Count, 0, averageZ.z / cellsPosition.Count);
        _midPosition = new Vector3(averageX.x / cellsPosition.Count, 0, averageZ.z / cellsPosition.Count);
    }
    
    private void OnTowerBuildRelease()
    {
        _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseClickSelectedTowerState);
    }
    
}