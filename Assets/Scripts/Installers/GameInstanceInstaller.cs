using Zenject;

public class GameInstanceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameInstance>().AsSingle().NonLazy();
    }
}
