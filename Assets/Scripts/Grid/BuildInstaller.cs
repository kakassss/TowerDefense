using UnityEngine;
using Zenject;

public class BuildInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BuildManager>().AsSingle().NonLazy();
        Container.Bind<GhostBuildManager>().AsSingle().NonLazy();
    }
}
