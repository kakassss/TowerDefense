using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Main InputSystem initializer
        Container.Bind<InputSystem>().AsSingle().NonLazy();
        
        //Readers
        Container.Bind<BuildingInputReader>().AsSingle().NonLazy();
        Container.Bind<MovementInputReader>().AsSingle().NonLazy();
        Container.Bind<IdleInputReader>().AsSingle().NonLazy();
        
        //Input Reader Events
        Container.Bind<BuildingInputEvents>().AsSingle().NonLazy();
    }
}