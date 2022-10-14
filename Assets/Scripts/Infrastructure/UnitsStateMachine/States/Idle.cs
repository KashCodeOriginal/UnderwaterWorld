using Pathfinding;
using UnityEngine;
using UnitsStateMachine;

public class Idle : State
{
    private readonly Enemy _enemy;
    private readonly IMoveable _moveable;
    private readonly AIDestinationSetter _aiDestinationSetter;

    public Idle(Enemy enemy, IMoveable moveable, AIDestinationSetter aiDestinationSetter)
    {
        _enemy = enemy;
        _moveable = moveable;
        _aiDestinationSetter = aiDestinationSetter;
    }
    
    public override void Tick()
    {
        Debug.Log("idle");
        _moveable.MoveToRandomPoint(_aiDestinationSetter);
    }
}
