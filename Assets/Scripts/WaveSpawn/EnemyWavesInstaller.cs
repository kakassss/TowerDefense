using Zenject;

public class EnemyWavesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyWavesPathFinding>().AsSingle().NonLazy();
    }
}
