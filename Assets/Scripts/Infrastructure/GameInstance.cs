public class GameInstance
{
    public GameInstance(IAssetsAddressableService assetsAddressableService, IUIFactory uiFactory, IAbstractFactory abstractFactory)
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new LoadingState(this, uiFactory),
            new SetUpState(this, abstractFactory, assetsAddressableService),
            new GameStartState(this, uiFactory),
            new GameplayState(this, uiFactory)
            );
        
        StateMachine.SwitchState<BootstrapState>();
    }
    

    public StateMachine<GameInstance> StateMachine;
}