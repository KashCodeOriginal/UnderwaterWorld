public class GameInstance
{
    public GameInstance(IUIFactory uiFactory)
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new LoadingState(this, uiFactory),
            new SetUpState(this),
            new GameStartState(this, uiFactory),
            new GameplayState(this)
            );
        
        StateMachine.SwitchState<BootstrapState>();
    }
    

    public StateMachine<GameInstance> StateMachine;
}