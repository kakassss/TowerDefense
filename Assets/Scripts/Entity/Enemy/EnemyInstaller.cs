using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BaseEnemyAttack>().AsSingle().NonLazy();
        Container.Bind<BaseEnemyDefence>().AsSingle().NonLazy();
        Container.Bind<BaseEnemyAnimator>().AsSingle().NonLazy();
    }
}
