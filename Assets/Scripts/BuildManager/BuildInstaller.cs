using UnityEngine;
using Zenject;

public class BuildInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GhostObjectReceiver>().AsSingle().NonLazy();
        Container.Bind<BuildManager>().AsSingle().NonLazy();
        Container.Bind<GhostBuildManager>().AsSingle().NonLazy();
        Container.Bind<BuildSelectManager>().AsSingle().NonLazy();
    }
}
