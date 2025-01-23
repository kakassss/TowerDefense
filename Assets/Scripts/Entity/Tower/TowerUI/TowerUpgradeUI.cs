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
        
        _upgradeButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _upgradeButton.gameObject.SetActive(false);
        _upgradeButton.onClick.RemoveListener(OnClick);
    }

    private void SetButtonState()
    {
        if(typeof(TankTower) != typeof(SelectedTowerReceiver)) return;
        _upgradeButton.gameObject.SetActive(true);
    }
    
    private void OnClick()
    {
        _towerUpgrade.IncreaseHealthStage(_selectedTowerReceiver);
    }
}