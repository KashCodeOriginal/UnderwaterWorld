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
    
    private IHunger _unitHunger;

    private IDamagable _unitDamageHandler;

    private AIDestinationSetter _aiDestinationSetter;

    private void Awake()
    {
        _movable = GetComponent<IAIMovable>();
        _eatable = GetComponent<IAIEatable>();
        _attackable = GetComponent<IAIAttackable>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();

        _unitDamageHandler = GetComponent<IDamagable>();

        _unitHunger = GetComponent<IHunger>();
        
        _stateMachine = new StateMachine();

        var idle = new Idle(this, _movable, _aiDestinationSetter);
        var findFood = new FindFood(this, _eatable, _aiDestinationSetter);
        var flee = new Flee(_unitDamageHandler, _aiDestinationSetter, _movable);

        AddTransition(idle, findFood, NeedFindFood);
        AddTransition(findFood, idle, CanIdle);
        AddTransition(flee, idle, Escaped);
        
        _stateMachine.AddAnyTransition(flee, Flee);
        //_stateMachine.AddAnyTransition();

        bool NeedFindFood() => _unitHunger.HungerPoints <= 60;  
        bool CanIdle() => _unitHunger.HungerPoints > 60 || _eatable.CurrentFoodTarget == null;
        bool Flee() => _unitDamageHandler.Attacker != null;
        bool Escaped() => _unitDamageHandler.Attacker == null;

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
