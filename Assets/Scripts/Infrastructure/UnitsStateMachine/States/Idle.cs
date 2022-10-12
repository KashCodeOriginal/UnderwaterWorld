using Pathfinding;
using UnitsStateMachine;

public class Idle : State
{
    private readonly Enemy _enemy;

    private readonly IMoveable _moveable;

    private AIDestinationSetter _aiDestinationSetter;

    public Idle(Enemy enemy, IMoveable moveable, AIDestinationSetter aiDestinationSetter)
    {
        _enemy = enemy;
        _moveable = moveable;
        _aiDestinationSetter = aiDestinationSetter;
    }
    
    public override void Tick()
    {
        _moveable.MoveToRandomPoint(_aiDestinationSetter);
    }
}
