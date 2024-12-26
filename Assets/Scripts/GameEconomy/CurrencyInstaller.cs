using Zenject;

public class CurrencyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameCurrency>().AsSingle().NonLazy();
    }
}
