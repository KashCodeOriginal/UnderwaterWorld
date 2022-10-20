using System;
using Pathfinding;
using UnityEngine;
using UnitsStateMachine;

public class Enemy : MonoBehaviour
{
    private StateMachine _stateMachine;

    private IAIMovable _movable;
    private IAIEatable _eatable;
    private IAIAttackable _attackable;
    
    private UnitHunger _unitHunger;

    private AIDestinationSetter _aiDestinationSetter;

    private void Awake()
    {
        _movable = GetComponent<IAIMovable>();
        _eatable = GetComponent<IAIEatable>();
        _attackable = GetComponent<IAIAttackable>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();

        _unitHunger = GetComponent<UnitHunger>();
        
        _stateMachine = new StateMachine();

        var idle = new Idle(this, _movable, _aiDestinationSetter);
        var findFood = new FindFood(this, _eatable ,_aiDestinationSetter);

        AddTransition(idle, findFood, NeedFood);
        AddTransition(findFood, idle, CanIdle);

        bool NeedFood() => _unitHunger.HungerPoint <= 60;  
        bool CanIdle() => _unitHunger.HungerPoint > 60 || _eatable.CurrentFoodTarget == null;

        _stateMachine.SetState(idle);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void AddTransition(State from, State to, Func<bool> condition)
    {
        _stateMachine.AddTransition(from, to, condition);
    }
}
