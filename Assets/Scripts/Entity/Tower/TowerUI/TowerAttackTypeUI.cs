using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TowerAttackTypeUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private List<Button> _attackTypeButtons;
    [SerializeField] private TextMeshProUGUI _attackDamageText;
    [SerializeField] private TextMeshProUGUI _elementTypeText;
    [SerializeField] private TextMeshProUGUI _healthText;
    
    private const string AttackDamage = "Attack: ";
    private const string ElementType = "Element: ";
    private const string Health = "Health: ";
    
    private SelectedTowerReceiver _selectedTowerReceiver;
    private TowerAttackTypeHolder _towerAttackTypeHolder;
    private TowerUpgrade _towerUpgrade;
    
    [Inject]
    private void Construct(TowerAttackTypeHolder towerAttackTypeHolder, SelectedTowerReceiver selectedTowerReceiver,
        TowerUpgrade towerUpgrade)
    {
        _towerAttackTypeHolder = towerAttackTypeHolder;
        _selectedTowerReceiver = selectedTowerReceiver;
        _towerUpgrade = towerUpgrade;
    }

    private void OnEnable()
    {
        SetButtons();
        SetTowerStats();

        _towerUpgrade.OnIncreaseHealth += SetHealth;
    }

    private void OnDisable()
    {
        _towerUpgrade.OnIncreaseHealth -= SetHealth;
    }

    private void OnDestroy()
    {
        _towerUpgrade.OnIncreaseHealth -= SetHealth;
    }

    private void SetTowerStats()
    {
        if(_selectedTowerReceiver == null) return;
        if(_elementTypeText == null && _attackDamageText == null) return;
        
        if(_elementTypeText == null) _elementTypeText.gameObject.SetActive(false);
        if(_attackDamageText == null ) _attackDamageText.gameObject.SetActive(false);
        
        _attackDamageText.text = AttackDamage + " " + _selectedTowerReceiver.SelectedTower.AttackStats.Damage;
        _elementTypeText.text = ElementType + " " + _selectedTowerReceiver.SelectedTower.AttackStats.ElementType;
        _healthText.text = Health + " " + _selectedTowerReceiver.SelectedTower.TowerHealth.CurrentHealth
                           + "/"+ _selectedTowerReceiver.SelectedTower.TowerHealth.MaxHealth;;
    }

    private void SetHealth()
    {
        _healthText.text = Health + " " + _selectedTowerReceiver.SelectedTower.TowerHealth.CurrentHealth 
                           + "/"+ _selectedTowerReceiver.SelectedTower.TowerHealth.MaxHealth;
    }
    
    private void SetButtons()
    {
        CloseButtons();
        
        for (int i = 0; i < _towerAttackTypeHolder.AttackTypesUI.Count; i++)
        {
            _attackTypeButtons[i].gameObject.SetActive(true);
        }
    }

    private void CloseButtons()
    {
        for (int i = 0; i < _attackTypeButtons.Count; i++)
        {
            _attackTypeButtons[i].gameObject.SetActive(false);
        }
        
    }

}
