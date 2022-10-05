using UnityEngine;

public class GameStartState : State<GameInstance>
{
    public GameStartState(GameInstance context, IUIFactory uiFactory) : base(context)
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
        
        Debug.Log(gameStartScreen.GetComponent<StartGameScreen>().gameObject);
        
        _startGameScreen.OnPlayButtonClicked += StartGame;
        
        Context.StateMachine.SwitchState<GameplayState>();
    }

    private void HideUI()
    {
        _uiFactory.DestroyGameStartScreen();
    }

    private void StartGame()
    {
        Context.StateMachine.SwitchState<GameplayState>();
    }
}
