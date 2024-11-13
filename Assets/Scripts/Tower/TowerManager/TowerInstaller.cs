using UnityEngine;
using Zenject;

public class TowerInstaller : MonoInstaller
{
    [Header("References")] 
    [SerializeField] private GridEntitySO _gridEntitySo;
    public override void InstallBindings()
    {
        Container.Bind<TowerEvents>().AsSingle().NonLazy();
        Container.Bind<TowerManager>().AsSingle().NonLazy();
        
        Container.Bind<TowerSpawn>().AsSingle().NonLazy();
        Container.Bind<GhostSpawn>().AsSingle().NonLazy();
        //Container.Bind<BaseSpawner>().AsSingle().NonLazy();
        Container.Bind<GridEntitySO>().FromScriptableObject(_gridEntitySo).AsSingle().NonLazy();
    }
}
