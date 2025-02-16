using System.Collections.Generic;
using UnityEngine;
using Zenject;

//Adressable system could be use
//unfinished test version
public class PopupManager
{
    private readonly IInstantiator _instantiator;
    private readonly Transform _popupContainerParent;
    private readonly (string, GameObject) _towerStats;
    
    private Dictionary<string, GameObject> _allPopups = new Dictionary<string, GameObject>();
    private List<GameObject> _activePopups = new List<GameObject>();
    private List<GameObject> _deActivePopups = new List<GameObject>();
    
    private GameObject _activePopup;
    
    public PopupManager((string, GameObject) towerStats, IInstantiator instantiator, Transform popupContainerParent)
    {
        _instantiator = instantiator;
        _towerStats = towerStats;
        _popupContainerParent = popupContainerParent;
        
        _allPopups.Add(_towerStats.Item1, _towerStats.Item2);
    }
    
    public void OpenPopupByName(string name)
    {
        if (_activePopup != null) return;
        
        _activePopup = _instantiator.InstantiatePrefab(GetPopupByName(name), _popupContainerParent);
    }
    
    public void OpenPopupByNameWithPosition(string name, Transform transform, Vector3 offSet)
    {
        if (_activePopup != null) return;
        
        _activePopup = _instantiator.InstantiatePrefab(GetPopupByName(name), _popupContainerParent);
        _activePopup.transform.position = transform.position + offSet;
    }
    
    public void ClosePopupByName(string name)
    {
        if (_activePopup == null) return;
        
        _activePopup.gameObject.SetActive(false);
        Object.Destroy(_activePopup.gameObject);
        _activePopup = null;
    }
    
    public GameObject GetPopupByName(string name)
    {
        return _allPopups[name];
    }
}
