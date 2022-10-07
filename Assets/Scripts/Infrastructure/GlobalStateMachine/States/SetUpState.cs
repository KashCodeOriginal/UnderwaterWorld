using UnityEngine;

public class SetUpState : State<GameInstance>
{
    public SetUpState(GameInstance context) : base(context) { }
    
    
    public override void Enter()
    {
        var foodSpawner = Object.FindObjectOfType<FoodSpawner>();
        foodSpawner.CreateFood();

        var enemySpawner = Object.FindObjectOfType<EnemySpawner>();
        enemySpawner.CreateEnemy();

        Context.StateMachine.SwitchState<GameStartState>();
    }
}