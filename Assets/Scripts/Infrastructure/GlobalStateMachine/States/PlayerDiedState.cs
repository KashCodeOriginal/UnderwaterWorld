public class PlayerDiedState : State<GameInstance>
{
    public PlayerDiedState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    private readonly IUIFactory _uiFactory;

    public override void Enter()
    {
        ShowUI();
    }

    public override void Exit()
    {
        HideUI();
    }

    private void ShowUI()
    {
        _uiFactory.CreatePlayerDiedScreen();
    }

    private void HideUI()
    {
        _uiFactory.DestroyPlayerDiedScreen();
    }
}