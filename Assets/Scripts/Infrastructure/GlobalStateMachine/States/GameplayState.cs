public class GameplayState : StateOneParam<GameInstance, GameplayScreen>
{
    public GameplayState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    private readonly IUIFactory _uiFactory;
    private GameplayScreen _gameplayScreen;
    
    public override void Enter(GameplayScreen arg0)
    {
        _gameplayScreen = arg0;
        
        _gameplayScreen.FloatingJoystick.gameObject.SetActive(true);
        _gameplayScreen.AttackButton.gameObject.SetActive(true);
        
        _uiFactory.DestroyLoadingScreen();
    }

    public override void Exit()
    {
        _uiFactory.DestroyGameplayScreen();
    }
}
