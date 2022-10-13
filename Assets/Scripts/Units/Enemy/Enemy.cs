using System;
using Pathfinding;
using UnityEngine;
using UnitsStateMachine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private bool _hasFoodTarget;

    private IStatsService _statsService;
    
    private StateMachine _stateMachine;
    
    public int Health => _health;

    private void Awake()
    {
        var _movement = GetComponent<IMoveable>();
        var _attack = GetComponent<IAttackable>();
        var _eat = GetComponent<IEatable>();
        var _aiDestinationSetter = GetComponent<AIDestinationSetter>();

        _stateMachine = new StateMachine();

        var idle = new Idle(this, _movement, _aiDestinationSetter);
        var eat = new Eat();

        AddTransition(idle, eat, HasTarget);
        AddTransition(eat, idle, NoTarget);

        bool HasTarget() => _hasFoodTarget;
        bool NoTarget() => !_hasFoodTarget;

        _stateMachine.SetState(idle);
    }

    private void Update()
    {
        _stateMachine.Tick();
        
        _statsService.DecreaseValue(ref _health, 3, 1, 10);
    }

    [Inject]
    public void Construct(IStatsService statsService)
    {
        _statsService = statsService;
    }

    public void Modify(int health)
    {
        _health += health;
    }

    private void AddTransition(State from, State to, Func<bool> condition)
    {
        _stateMachine.AddTransition(from, to, condition);
    }
}
