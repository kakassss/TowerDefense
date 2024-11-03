using UnityEngine;
using Zenject;

public class BuildInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GhostObjectReceiver>().AsSingle().NonLazy(); // TODO İŞ YERİNDEKİ INSTANTİATOR TARZI Bİ ŞEY LAZIM
        Container.Bind<BuildManager>().AsSingle().NonLazy();
        Container.Bind<GhostBuildManager>().AsSingle().NonLazy();
    }
}
