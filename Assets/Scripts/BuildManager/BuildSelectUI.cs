using TMPro;
using UnityEngine;
using Zenject;

public class BuildSelectUI : AbstractButtonListener
{
    [SerializeField] private GridEntitySO _gridEntitySo;
    [SerializeField] private TMP_Text _buttonNameText;
    
    private InputActions _inputActions;

    [Inject]
    private void Construct(InputActions inputActions)
    {
        _inputActions = inputActions;
        
        SetButtonActions();
    }

    private void SetButtonActions()
    {
        _buttonNameText.text = _gridEntitySo.Name;
    }

    protected override void OnclickListener()
    {
        base.OnclickListener();
        
        _inputActions.GhostSpawnInputAction(_gridEntitySo);
    }
}