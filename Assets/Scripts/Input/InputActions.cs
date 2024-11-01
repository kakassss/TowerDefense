using System;

public class InputActions
{
    private Action OnSpawnInput;
    private Action OnGhostSpawnInput;

    public void SpawnInputAction()
    {
        OnSpawnInput?.Invoke();
    }

    public void SpawnInputAddAction(Action action)
    {
        OnSpawnInput += action;
    }

    public void SpawnInputRemoveAction(Action action)
    {
        OnSpawnInput -= action;
    }
    
    public void GhostSpawnInputAction()
    {
        OnGhostSpawnInput?.Invoke();
    }

    public void GhostSpawnInputAddAction(Action action)
    {
        OnGhostSpawnInput += action;
    }

    public void GhostSpawnInputRemoveAction(Action action)
    {
        OnGhostSpawnInput -= action;
    }
}
