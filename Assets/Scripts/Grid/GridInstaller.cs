using UnityEngine;
using Zenject;

public class GridInstaller : MonoInstaller
{
    [SerializeField] private GridSOData gridData;
    
    public override void InstallBindings()
    {
        Container.Bind<GridSOData>().FromScriptableObject(gridData).AsSingle().NonLazy();
        Container.Bind<CellManager>().AsSingle().WithArguments(gridData).NonLazy();
        Container.Bind<CellPowerManager>().AsSingle().NonLazy();
    }
}
