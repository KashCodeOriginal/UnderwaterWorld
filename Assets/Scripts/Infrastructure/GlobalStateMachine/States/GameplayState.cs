using UnityEngine;

public class GameplayState : State<GameInstance>
{
    public GameplayState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    private readonly IUIFactory _uiFactory;
    
    public override void Enter()
    {
        _uiFactory.DestroyLoadingScreen();
    }

    public override void Exit()
    {
        _uiFactory.DestroyGameplayScreen();
    }
}
