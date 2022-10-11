using UnityEngine;
using UnitsStateMachine;

public class Idle : State
{
    private readonly Enemy _enemy;

    private readonly IMoveable _moveable;

    public Idle(Enemy enemy, IMoveable moveable)
    {
        _enemy = enemy;
        _moveable = moveable;
    }
    
    public override void Tick()
    {
        Debug.Log($"Иду у меня {_enemy.Health} жизней и скорость {_moveable.Speed}");
    }
}
