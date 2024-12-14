using Zenject;

public class BuildButtonListener : AbstractButtonListener
{
    private MouseClickStateEvents _mouseClickStateEvents;

    [Inject]
    private void Construct(MouseClickStateEvents mouseClickStateEvents)
    {
        _mouseClickStateEvents = mouseClickStateEvents;
    }
    
    protected override void OnClickListener()
    {
        base.OnClickListener();
        _mouseClickStateEvents.OnTowerBuildStart?.Invoke();    
    }
}
