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
        ShowUI();
    }

    private async void ShowUI()
    {
        var gameplayScreen = await _uiFactory.CreateGameplayScreen();
        
    }

    private void HideUI()
    {
        _uiFactory.DestroyGameplayScreen();
    }
}