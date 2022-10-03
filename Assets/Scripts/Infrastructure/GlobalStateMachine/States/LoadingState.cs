using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadingState : State<GameInstance>
{
    private readonly IUIFactory _uiFactory;
    private LoadingGameScreen _loadingGameScreen;

    public LoadingState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    public override async void Enter()
    {
        ShowUI();
        
        var asyncOperationHandle = Addressables.LoadSceneAsync(GameConstants.GAMEPLAY_LEVEL_NAME);
        await asyncOperationHandle.Task;
        OnLoadingComplete();
    }

    public override void Exit()
    {
        HideUI();
    }

    private void OnLoadingComplete()
    {
        Context.StateMachine.SwitchState<SetUpState>();
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