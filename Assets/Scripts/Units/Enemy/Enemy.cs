using System;
using Zenject;
using Pathfinding;
using UnityEngine;
using UnitsStateMachine;

public class Enemy : MonoBehaviour
{
    public const int MAX_HUNGER_POINTS = 100;

    [SerializeField] private int _healthPoints;

    [SerializeField] private int _hungerPoints;

    private bool _hasFoodTarget;
    
    private bool _hasLowHunger;

    private StatsService _statsService;
    
    private StateMachine _stateMachine;

    private EnemyEat _enemyEat;
    
    public int HealthPoints => _healthPoints;

    public int HungerPoints => _hungerPoints;

    private void Awake()
    {
        _enemyEat = GetComponent<EnemyEat>();
        
        var _movement = GetComponent<IMoveable>();
        var _attack = GetComponent<IAttackable>();
        var _eat = GetComponent<IEatable>();
        var _aiDestinationSetter = GetComponent<AIDestinationSetter>();

        _stateMachine = new StateMachine();

        _statsService = new StatsService();

        var idle = new Idle(this, _movement, _aiDestinationSetter);
        var eat = new Eat();

        AddTransition(idle, eat, HasTarget);

        bool HasTarget() => _hasFoodTarget;
        //bool NoTarget() => !_hasFoodTarget;

        _stateMachine.SetState(idle);
    }

    private void Start()
    {
        _hungerPoints = MAX_HUNGER_POINTS;
    }

    private void Update()
    {
        _stateMachine.Tick();
        
        _statsService.DecreaseValue(ref _hungerPoints, 6, 2, 0);
    }

    public void Modify(int health)
    {
        _healthPoints += health;
    }

    private void AddTransition(State from, State to, Func<bool> condition)
    {
        _stateMachine.AddTransition(from, to, condition);
    }

    private void IncreaseHunger(int increaseValue)
    {
        _hungerPoints += increaseValue;
    }

    private void OnEnable()
    {
        _enemyEat.IncreaseHunger += IncreaseHunger;
    }

    private void OnDisable()
    {
        _enemyEat.IncreaseHunger -= IncreaseHunger;
    }
}
