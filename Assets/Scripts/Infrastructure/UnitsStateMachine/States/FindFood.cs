using Pathfinding;
using UnitsStateMachine;
using UnityEngine;

public class FindFood : State
{
    private readonly Enemy _enemy;
    private readonly IAIEatable _enemyEat;
    private readonly AIDestinationSetter _aiDestinationSetter;
    
    public FindFood(Enemy enemy, IAIEatable enemyEat, AIDestinationSetter aiDestinationSetter)
    {
        _enemy = enemy;
        _enemyEat = enemyEat;
        _aiDestinationSetter = aiDestinationSetter;
    }

    public override void Tick()
    {
        Debug.Log("Ищу еду");
        _enemyEat.TryFindClosestFood(_aiDestinationSetter);
    }
}
