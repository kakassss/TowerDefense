using Zenject;

public class TowerAttackInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Attack Types
        Container.BindInterfacesAndSelfTo<TowerAttackMostHp>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TowerAttackClosest>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TowerAttackNoAttack>().AsSingle().NonLazy();
        
        //Tower Types
        Container.BindInterfacesAndSelfTo<TowerSphereIRangeType>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TowerBoxIRangeType>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TowerTankIRangeType>().AsSingle().NonLazy();
        
        //Base Tower
        Container.Bind<BaseTowerAttack>().AsSingle().NonLazy();
        
        
        //Type holders & Receivers
        Container.Bind<TowerAttackTypeHolder>().AsSingle().NonLazy();
        Container.Bind<TowerRangeTypeHolder>().AsSingle().NonLazy();
        Container.Bind<SelectedTowerReceiver>().AsSingle().NonLazy();
    }
}
