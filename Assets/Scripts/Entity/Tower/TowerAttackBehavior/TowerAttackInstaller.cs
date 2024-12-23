using Zenject;

public class TowerAttackInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TowerAttackMostHp>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TowerAttackClosest>().AsSingle().NonLazy();
        Container.Bind<BaseTowerAttack>().AsSingle().NonLazy();

        Container.Bind<TowerAttackTypeHolder>().AsSingle().NonLazy();
        Container.Bind<SelectedTowerReceiver>().AsSingle().NonLazy();
    }
}
