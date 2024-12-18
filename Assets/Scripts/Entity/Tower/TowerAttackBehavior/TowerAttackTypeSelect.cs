using UnityEngine;
using Zenject;

public class TowerAttackTypeReceiver
{
    public BaseTower SelectedTower;
}

public class TowerAttackTypeSelect : AbstractButtonListener
{
    private ITargetToEnemy SelectedAttackType;

    [SerializeField] private AttackTypeEnum _attackTypeEnum;
    
    private TowerAttackTypeReceiver _towerAttackTypeReceiver;
    private TowerAttackTypeHolder _towerAttackTypeHolder;
    
    [Inject]
    private void Construct(TowerAttackTypeHolder towerAttackTypeHolder,TowerAttackTypeReceiver towerAttackTypeReceiver)
    {
        _towerAttackTypeReceiver = towerAttackTypeReceiver;
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
        _towerAttackTypeReceiver.SelectedTower.AttackType = SelectedAttackType;
    }
}
