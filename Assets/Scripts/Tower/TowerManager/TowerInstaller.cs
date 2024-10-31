using UnityEngine;
using Zenject;

public class TowerInstaller : MonoInstaller
{
    [Header("References")] 
    [SerializeField] private TowerPrefabSO _towerPrefabSo;
    [SerializeField] private GridEntitySO _gridEntitySo;
    [SerializeField] private LayerMask _towarSpawnLayerMask;
    [SerializeField] private Camera _camera;
 
    public override void InstallBindings()
    {
        Container.Bind<TowerEvents>().AsSingle().NonLazy();
        Container.Bind<TowerManager>().AsSingle().NonLazy();
        
        Container.Bind<TowerSpawn>().AsSingle().WithArguments(_towarSpawnLayerMask,_camera).NonLazy();
        Container.Bind<TowerPrefabSO>().FromScriptableObject(_towerPrefabSo).AsSingle().NonLazy();
        Container.Bind<GridEntitySO>().FromScriptableObject(_gridEntitySo).AsSingle().NonLazy();
    }
}
