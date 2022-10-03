using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFoodFactory();
        BindUIFactory();
        BindSceneLoader();
        BindAssetsAddressable();
    }

    private void BindSceneLoader()
    {
        Container.BindInterfacesTo<SceneLoader>().AsSingle();
    }

    private void BindAssetsAddressable()
    {
        Container.BindInterfacesTo<AssetsAddressable>().AsSingle();
    }

    private void BindFoodFactory()
    {
        Container.BindInterfacesTo<FoodFabric>().AsSingle();
    }

    private void BindUIFactory()
    {
        Container.BindInterfacesTo<UIFactory>().AsSingle();
    }
}
