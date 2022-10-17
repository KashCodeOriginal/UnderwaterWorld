using UnityEngine.AddressableAssets;

public class SceneLoadingState : State<GameInstance>
{
    private readonly IUIFactory _uiFactory;
    private LoadingGameScreen _loadingGameScreen;

    public SceneLoadingState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    public override async void Enter()
    {
        ShowUI();
        
        var asyncOperationHandle = Addressables.LoadSceneAsync(AssetsAddressesConstants.GAMEPLAY_LEVEL_NAME);
        await asyncOperationHandle.Task;
        OnLoadingComplete();
    }

    public override void Exit()
    {
        HideUI();
    }

    private void OnLoadingComplete()
    {
        Context.StateMachine.SwitchState<GameStartMenuState>();
    }

    private void ShowUI()
    {
        _uiFactory.CreateLoadingScreen();
    }

    private void HideUI()
    {
        _uiFactory.DestroyLoadingScreen();
    }
}