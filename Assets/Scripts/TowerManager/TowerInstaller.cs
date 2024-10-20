using UnityEngine;
using Zenject;

public class TowerInstaller : MonoInstaller
{
    [Header("References")] 
    [SerializeField] private TowerPrefabSO _towerPrefabSo;
    [SerializeField] private LayerMask _towarSpawnLayerMask;
 
    public override void InstallBindings()
    {
        Container.Bind<TowerEvents>().AsSingle().NonLazy();
        Container.Bind<TowerSpawn>().AsSingle().WithArguments(_towarSpawnLayerMask).NonLazy();
        Container.Bind<TowerPrefabSO>().FromScriptableObject(_towerPrefabSo).AsSingle().NonLazy();
    }
}
