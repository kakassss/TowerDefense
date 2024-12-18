using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TowerAttackTypeUI : MonoBehaviour
{
    [SerializeField] private List<Button> _attackTypeButtons;

    private TowerAttackTypeHolder _towerAttackTypeHolder;

    [Inject]
    private void Construct(TowerAttackTypeHolder towerAttackTypeHolder)
    {
        _towerAttackTypeHolder = towerAttackTypeHolder;
    }

    private void OnEnable()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        CloseButtons();
        
        for (int i = 0; i < _towerAttackTypeHolder.AttackTypes.Count; i++)
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
