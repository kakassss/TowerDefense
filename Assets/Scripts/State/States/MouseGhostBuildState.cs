using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseGhostBuildState : MouseClickBaseState
{
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;

    private Grid<Cell> _mouseCell;
    private List<Cell> _buildableCells = new List<Cell>();
    
    private BuildingInputReader _buildingInputReader;
    
    private MouseClickStateEvents _mouseClickStateEvents;
    
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

    private (int x, int z) XZTuple;
    
    private void CalculateGridPos()
    {
        if (_buildableCells != null)
        {
            
            
            if (Vector3.Distance(_midPosition, _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask()) <=
                _midPosOffset)
            {
                _ghostObjectReceiver.GameObject.transform.position = _midPosition;
                Debug.Log("onur xd3 " +
                          Vector3.Distance(_midPosition, _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask()));
            }
            else
            {
                CalculateGridPos();
            }
        }

        void CalculateGridPos()
        {
            XZTuple = _cellManager.GetXZ(_mouseClickStateMachine.Utils.GetValidPositionWithLayerMask(),XZTuple.x, XZTuple.z);

            _buildableCells.Clear();

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
                        Debug.Log("onur xd2");            
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
        List<Vector3> cellsPosition = _buildableCells.Select(cell => _cellManager.GetCellMidPointPositionXZ(cell.GridIndexX, cell.GridIndexZ)).ToList();

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

    private Vector3 _midPosition;
    private float _midPosOffset = 3f;
    private void SetMidCell()
    {
        if (Vector3.Distance(_midPosition, _mouseClickStateMachine.Utils.GetValidPositionWithLayerMask()) <=
            _midPosOffset)
        {
            //_ghostObjectReceiver.GameObject.transform.position = new Vector3(averageX.x / cellsPosition.Count, 0, averageZ.z / cellsPosition.Count);
        }
    }
    
    private void OnTowerBuildRelease()
    {
        _mouseClickStateMachine.SwitchState(_mouseClickStateMachine.MouseClickSelectedTowerState);
    }
    
}