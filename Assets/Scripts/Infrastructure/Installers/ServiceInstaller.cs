using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
    }

    private void BindSceneLoader()
    {
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
    }
}
