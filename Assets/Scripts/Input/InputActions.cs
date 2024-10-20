using System;

public class InputActions
{
    private Action OnSpawnInput;

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
}
