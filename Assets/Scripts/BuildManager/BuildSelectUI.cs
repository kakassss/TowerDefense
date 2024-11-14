using TMPro;
using UnityEngine;
using Zenject;

public class BuildSelectUI : AbstractButtonListener
{
    [SerializeField] private TMP_Text _buttonNameText;
    [SerializeField] private int _towerIndex; // TODO: İleride sorun cıkarır değişmesi lazım
    
    private GridEntitySO _gridEntitySo;
    private InputActions _inputActions;

    private BuildUI _buildUI;
    
    [Inject]
    private void Construct(InputActions inputActions, GridEntitySO gridEntitySo)
    {
        _inputActions = inputActions;
        _gridEntitySo = gridEntitySo;
    }

    private void Start()
    {
        SetButtonActions();
    }

    public void SetBuildButton(BuildUI buildUI)
    {
        _buildUI = buildUI;
    }
    
    private void SetButtonActions()
    {
        _buttonNameText.text = _gridEntitySo.BaseObjects[_buildUI.TowerIndex].Name;
    }

    protected override void OnclickListener()
    {
        base.OnclickListener();
        
        _inputActions.GhostSpawnInputAction(_gridEntitySo.BaseObjects[_buildUI.TowerIndex]);
    }
}