using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputReader>().AsSingle().NonLazy();
        Container.Bind<InputActions>().AsSingle().NonLazy();
    }
}