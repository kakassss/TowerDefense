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

    private const string AttackDamage = "Attack: ";
    private const string ElementType = "Element: ";
    
    private SelectedTowerReceiver _selectedTowerReceiver;
    private TowerAttackTypeHolder _towerAttackTypeHolder;

    [Inject]
    private void Construct(TowerAttackTypeHolder towerAttackTypeHolder, SelectedTowerReceiver selectedTowerReceiver)
    {
        _towerAttackTypeHolder = towerAttackTypeHolder;
        _selectedTowerReceiver = selectedTowerReceiver;
    }

    private void OnEnable()
    {
        SetButtons();
        SetTowerStats();
    }

    private void SetTowerStats()
    {
        if(_selectedTowerReceiver == null) return;
        if(_elementTypeText == null && _attackDamageText == null) return;
        
        if(_elementTypeText == null) _elementTypeText.gameObject.SetActive(false);
        if(_attackDamageText == null ) _attackDamageText.gameObject.SetActive(false);
        
        _attackDamageText.text = AttackDamage + " " + _selectedTowerReceiver.SelectedTower.AttackStats.Damage;
        _elementTypeText.text = ElementType + " " + _selectedTowerReceiver.SelectedTower.AttackStats.ElementType;
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
