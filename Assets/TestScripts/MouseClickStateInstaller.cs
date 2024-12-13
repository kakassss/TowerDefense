using Zenject;

public class MouseClickStateInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MouseClickStateEvents>().AsSingle().NonLazy();
    }
}
