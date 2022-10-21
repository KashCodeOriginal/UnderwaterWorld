using Pathfinding;
using UnitsStateMachine;
using UnityEngine;

public class Flee : State
{
    public Flee(IDamagable unitDamageHandler, AIDestinationSetter aiDestinationSetter, IAIMovable movable)
    {
        _unitDamageHandler = unitDamageHandler;
        _aiDestinationSetter = aiDestinationSetter;
        _movable = movable;
    }
    
    private readonly IDamagable _unitDamageHandler;
    private readonly AIDestinationSetter _aiDestinationSetter;
    private readonly IAIMovable _movable;

    public override void Enter()
    {
        Debug.Log("Зашло");
        _movable.MoveAwayFromAttacker(_aiDestinationSetter, _unitDamageHandler.Attacker.transform);
    }
}
