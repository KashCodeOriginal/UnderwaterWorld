using UnityEngine;

public class LoadingState : State<GameInstance>
{
    public LoadingState(GameInstance context, ISceneLoader sceneLoader) : base(context)
    {
        _sceneLoader = sceneLoader;
    }

    private readonly ISceneLoader _sceneLoader;

    public override void Enter()
    {
        _sceneLoader.LoadScene(GameConstants.GAMEPLAY_LEVEL_NAME, OnLoadingComplete);
    }

    private void OnLoadingComplete()
    {
        Context.StateMachine.SwitchState<SetUpState>();
    }
}