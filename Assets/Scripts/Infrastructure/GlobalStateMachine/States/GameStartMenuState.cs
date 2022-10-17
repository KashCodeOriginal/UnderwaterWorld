using UnityEngine;

public class GameStartMenuState : State<GameInstance>
{
    public GameStartMenuState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    private readonly IUIFactory _uiFactory;

    private StartGameScreen _startGameScreen;

    public override void Enter()
    {
        ShowUI();
    }

    public override void Exit()
    {
        HideUI();
    }

    private async void ShowUI()
    {
        var gameStartScreen = await _uiFactory.CreateGameStartScreen();

        _startGameScreen = gameStartScreen.GetComponent<StartGameScreen>();

        _startGameScreen.OnPlayButtonClicked += StartGame;
    }

    private void HideUI()
    {
        _uiFactory.DestroyGameStartScreen();
    }

    private void StartGame()
    {
        Context.StateMachine.SwitchState<GameplaySetUpState>();
    }
}
