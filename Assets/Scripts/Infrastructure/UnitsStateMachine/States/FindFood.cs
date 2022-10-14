using Pathfinding;
using UnitsStateMachine;
using UnityEngine;

public class FindFood : State
{
    private readonly Enemy _enemy;
    private readonly EnemyEat _enemyEat;
    private readonly AIDestinationSetter _aiDestinationSetter;
    
    public FindFood(Enemy enemy, EnemyEat enemyEat, AIDestinationSetter aiDestinationSetter)
    {
        _enemy = enemy;
        _enemyEat = enemyEat;
        _aiDestinationSetter = aiDestinationSetter;
    }

    public override void Tick()
    {
        Debug.Log("eat");
        _enemyEat.TryFindClosestFood(_aiDestinationSetter);
    }
}
