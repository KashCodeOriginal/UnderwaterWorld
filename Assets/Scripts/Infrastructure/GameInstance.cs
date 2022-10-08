public class GameInstance
{
    public GameInstance(IAssetsAddressableService assetsAddressableService, IUIFactory uiFactory, IAbstractFactory abstractFactory)
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new SetUpLoadingState(this, uiFactory),
            new SetUpState(this),
            new GameStartState(this, uiFactory),
            new GameplayState(this, uiFactory, abstractFactory, assetsAddressableService)
            );
        
        StateMachine.SwitchState<BootstrapState>();
    }
    

    public StateMachine<GameInstance> StateMachine;
}