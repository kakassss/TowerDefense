using System;
using UnityEngine;

public class GhostSpawn : BaseSpawner, IDisposable
{
    private GhostBuildManager _ghostBuildManager;
    
    private new Vector3 _spawnPos;
    
    private GhostSpawn(Utils utils, GhostBuildManager ghostBuildManager, BuildingInputEvents buildingInputEvents) : base(utils,buildingInputEvents)
    {
        _ghostBuildManager = ghostBuildManager;
        
        BuildingInputEvents.GhostSpawnInputAddAction(Spawn);
    }
    
    private void Spawn(BaseObject gridEntitySo)
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask();
        if(_spawnPos == Vector3.zero) return;
        _ghostBuildManager.BuildAction();
    }
    
    public void Dispose()
    {
        BuildingInputEvents.GhostSpawnInputRemoveAction(Spawn);
    }
}