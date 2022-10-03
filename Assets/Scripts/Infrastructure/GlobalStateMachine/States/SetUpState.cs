using UnityEngine;

public class SetUpState : State<GameInstance>
{
    private readonly IUIFactory _uiFactory;
    
    public SetUpState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }
    public override void Enter()
    {
        ShowUI();
        
        var foodSpawner = Object.FindObjectOfType<FoodSpawner>();
        
        foodSpawner.CreateFood();

        Context.StateMachine.SwitchState<SimulationState>();
    }

    public override void Exit()
    {
        HideUI();
    }

    private void ShowUI()
    {
        _uiFactory.CreateGameStartScreen();
    }

    private void HideUI()
    {
        _uiFactory.DestroyGameStartScreen();
    }
}