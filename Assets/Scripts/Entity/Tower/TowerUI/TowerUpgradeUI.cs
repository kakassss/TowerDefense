using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TowerUpgradeUI : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;

    private TowerUpgrade _towerUpgrade;
    private SelectedTowerReceiver _selectedTowerReceiver;
    
    [Inject]
    private void Construct(TowerUpgrade towerUpgrade, SelectedTowerReceiver selectedTowerReceiver)
    {
        _towerUpgrade = towerUpgrade;
        _selectedTowerReceiver = selectedTowerReceiver;
    }
    
    private void OnEnable()
    {
        SetButtonState();
        
        _selectedTowerReceiver.SelectedTower.TowerHealth.OnHealthUpgradeFinish += SetButtonState;
        _upgradeButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _selectedTowerReceiver.SelectedTower.TowerHealth.OnHealthUpgradeFinish -= SetButtonState;
        
        _upgradeButton.gameObject.SetActive(false);
        _upgradeButton.onClick.RemoveListener(OnClick);
    }

    private void SetButtonState()
    {
        if (_selectedTowerReceiver.SelectedTower.TowerHealth.Upgradeable == false)
        {
            _upgradeButton.gameObject.SetActive(false);    
            return;
        }
        _upgradeButton.gameObject.SetActive(true);
    }
    
    private void OnClick()
    {
        _towerUpgrade.IncreaseHealthStage(_selectedTowerReceiver);
    }
}