using TMPro;
using UnityEngine;
using Zenject;

public class BuildSelectUI : AbstractButtonListener
{
    [SerializeField] private TMP_Text _buttonNameText;
    
    private GridEntitySO _gridEntitySo;
    private BuildingInputEvents _buildingInputEvents;

    private BuildUI _buildUI;
    
    [Inject]
    private void Construct(BuildingInputEvents buildingInputEvents, GridEntitySO gridEntitySo)
    {
        _buildingInputEvents = buildingInputEvents;
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

    protected override void OnClickListener()
    {
        base.OnClickListener();
        
        _buildingInputEvents.GhostSpawnInputAction(_gridEntitySo.BaseObjects[_buildUI.TowerIndex]);
    }
}