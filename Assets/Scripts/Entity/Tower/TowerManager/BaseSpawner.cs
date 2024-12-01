using UnityEngine;

public abstract class BaseSpawner
{
    protected Utils _utils;
    protected InputActions _inputActions;
    
    protected Vector3 _spawnPos;
    
    protected BaseSpawner(
        Utils utils, InputActions inputActions)
    {
        _utils = utils;
        _inputActions = inputActions;
        
    }
}