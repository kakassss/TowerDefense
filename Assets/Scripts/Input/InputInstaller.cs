using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [Header("Keyboard")]
    [SerializeField] private GameObject _movementRelativeGO;
    
    public override void InstallBindings()
    {
        //Main InputSystem initializer
        Container.Bind<InputSystem>().AsSingle().NonLazy();
        
        //Readers
        Container.Bind<BuildingInputReader>().AsSingle().NonLazy();
        Container.Bind<MovementInputReader>().AsSingle().WithArguments(_movementRelativeGO).NonLazy();
        Container.Bind<IdleInputReader>().AsSingle().NonLazy();
        
        //Input Reader Events
        Container.Bind<BuildingInputEvents>().AsSingle().NonLazy();
    }
}