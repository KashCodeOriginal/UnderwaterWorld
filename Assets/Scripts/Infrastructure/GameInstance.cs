public class GameInstance
{
    public GameInstance(IUIFactory uiFactory)
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new LoadingState(this, uiFactory),
            new SetUpState(this, uiFactory),
            new SimulationState(this));
        
        StateMachine.SwitchState<BootstrapState>();
    }
    

    public StateMachine<GameInstance> StateMachine;
}