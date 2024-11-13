using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class BuildSelectUI : AbstractButtonListener
{
    [SerializeField] private TMP_Text _buttonNameText;
    [SerializeField] private int _towerIndex; // TODO: İleride sorun cıkarır değişmesi lazım
    
    private GridEntitySO _gridEntitySo;
    private InputActions _inputActions;

    [Inject]
    private void Construct(InputActions inputActions, GridEntitySO gridEntitySo)
    {
        _inputActions = inputActions;
        _gridEntitySo = gridEntitySo;
        
        SetButtonActions();
    }

    private void SetButtonActions()
    {
        _buttonNameText.text = _gridEntitySo.BaseObjects[_towerIndex].Name;
    }

    protected override void OnclickListener()
    {
        base.OnclickListener();
        
        _inputActions.GhostSpawnInputAction(_gridEntitySo.BaseObjects[_towerIndex]);
    }
}