using System;
using UnityEngine;

public class GhostSpawn : BaseSpawner, IDisposable
{
    private GhostBuildManager _ghostBuildManager;
    
    private Vector3 _spawnPos;
    
    private GhostSpawn(Utils utils, GhostBuildManager ghostBuildManager, InputActions inputActions) : base(utils,inputActions)
    {
        _ghostBuildManager = ghostBuildManager;
        
        _inputActions.GhostSpawnInputAddAction(Spawn);
    }
    
    private void Spawn(BaseObject gridEntitySo)
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask();
        if(_spawnPos == Vector3.zero) return;
        _ghostBuildManager.BuildAction();
    }
    
    public void Dispose()
    {
        _inputActions.GhostSpawnInputRemoveAction(Spawn);
    }
}