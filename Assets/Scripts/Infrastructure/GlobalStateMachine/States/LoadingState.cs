using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class LoadingState : State<GameInstance>
{
    public LoadingState(GameInstance context, ISceneLoader sceneLoader) : base(context)
    {
        
    }
    
    public async override void Enter()
    {
        var asyncOperationHandle = Addressables.LoadSceneAsync(GameConstants.GAMEPLAY_LEVEL_NAME, LoadSceneMode.Single);
        await asyncOperationHandle.Task;
        OnLoadingComplete();
        //_sceneLoader.LoadScene(GameConstants.GAMEPLAY_LEVEL_NAME, OnLoadingComplete);
    }

    private void OnLoadingComplete()
    {
        Context.StateMachine.SwitchState<SetUpState>();
    }
}