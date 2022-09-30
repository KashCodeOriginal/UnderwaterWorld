public class GameInstance
{
    public GameInstance(ISceneLoader sceneLoader)
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new LoadingState(this, sceneLoader),
            new SetUpState(this),
            new SimulationState(this));
        
        StateMachine.SwitchState<BootstrapState>();
    }
    

    public StateMachine<GameInstance> StateMachine;
}