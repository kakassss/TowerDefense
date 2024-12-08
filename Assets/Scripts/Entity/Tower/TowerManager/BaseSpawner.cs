using UnityEngine;

public abstract class BaseSpawner
{
    protected Utils _utils;
    protected BuildingInputEvents BuildingInputEvents;
    
    protected Vector3 _spawnPos;
    
    protected BaseSpawner(
        Utils utils, BuildingInputEvents buildingInputEvents)
    {
        _utils = utils;
        BuildingInputEvents = buildingInputEvents;
        
    }
}