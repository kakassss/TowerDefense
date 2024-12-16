using UnityEngine;
using Zenject;

public class PopupInstaller : MonoInstaller
{
    [SerializeField] private Transform _popupContainerParent;
    
    
    [SerializeField] private GameObject _towerStatsPopupPrefab;
    [SerializeField] private string _towerStatsPopupName;
    private (string,GameObject) _towerStatsContainer;
    
    public override void InstallBindings()
    {
        _towerStatsContainer.Item1 = _towerStatsPopupName;
        _towerStatsContainer.Item2 = _towerStatsPopupPrefab;
        
        Container.Bind<PopupManager>().AsSingle().WithArguments(_towerStatsContainer,_popupContainerParent).NonLazy();
    }
}
