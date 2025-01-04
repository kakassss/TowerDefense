using Zenject;

public class GameCurrencyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameCurrency>().AsSingle().NonLazy();
    }
}
