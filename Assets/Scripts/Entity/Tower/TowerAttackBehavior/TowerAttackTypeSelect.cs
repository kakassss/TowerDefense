using UnityEngine;
using Zenject;

public class SelectedTowerReceiver
{
    public BaseTower SelectedTower;
}

public class TowerAttackTypeSelect : AbstractButtonListener
{
    private IAttackType SelectedAttackType;

    [SerializeField] private AttackTypeEnum _attackTypeEnum;
    
    private SelectedTowerReceiver _selectedTowerReceiver;
    private TowerAttackTypeHolder _towerAttackTypeHolder;
    
    [Inject]
    private void Construct(TowerAttackTypeHolder towerAttackTypeHolder,SelectedTowerReceiver selectedTowerReceiver)
    {
        _selectedTowerReceiver = selectedTowerReceiver;
        _towerAttackTypeHolder = towerAttackTypeHolder;
        
        //Not necessary for init process, every tower has own default attackTypes defined at BaseTower.cs
        //SelectedTarget = towerAttackTypeHolder.AttackTypes[0]; // Set Closest Attack type as default
    }

    protected override void OnClickListener()
    {
        ChangeAttackType();
    }

    private void ChangeAttackType()
    {
        SelectedAttackType = _towerAttackTypeHolder.AttackTypes[(int)_attackTypeEnum];
        _selectedTowerReceiver.SelectedTower.AttackType = SelectedAttackType;
    }
}
