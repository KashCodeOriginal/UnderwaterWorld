public class GameInstance
{
    public GameInstance(IAssetsAddressableService assetsAddressableService, IUIFactory uiFactory, IAbstractFactory abstractFactory, IFoodRelationService foodRelationService, GameSettings gameSettings)
    {
        StateMachine = new StateMachine<GameInstance>(this,
            new BootstrapState(this),
            new SceneLoadingState(this, uiFactory),
            new GameStartMenuState(this, uiFactory),
            new GameplaySetUpState(this, uiFactory, foodRelationService, abstractFactory, assetsAddressableService, gameSettings),
            new GameplayState(this, uiFactory)
            );
        
        StateMachine.SwitchState<BootstrapState>();
    }
    

    public readonly StateMachine<GameInstance> StateMachine;
}