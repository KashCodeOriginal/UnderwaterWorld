public class GameInstance
{
    public GameInstance()
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new LoadingState(this),
            new SetUpState(this),
            new SimulationState(this));
        
        StateMachine.SwitchState<BootstrapState>();
    }

    public StateMachine<GameInstance> StateMachine;
}