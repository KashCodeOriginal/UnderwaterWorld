using Zenject;

public class GameInstanceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindGameInstance();
    }

    private void BindGameInstance()
    {
        Container.Bind<GameInstance>().AsSingle().NonLazy();
    }
}
