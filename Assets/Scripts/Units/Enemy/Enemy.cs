using System;
using Pathfinding;
using UnityEngine;
using UnitsStateMachine;

public class Enemy : MonoBehaviour
{
    public const int MAX_HUNGER_POINTS = 100;

    [SerializeField] private int _healthPoints;

    [SerializeField] private int _hungerPoints;

    private StatsService _statsService;
    
    private StateMachine _stateMachine;

    private IAIMovable _movable;
    private IAIEatable _eatable;
    private IAIAttackable _attackable;

    private AIDestinationSetter _aiDestinationSetter;

    public int HealthPoints => _healthPoints;

    public int HungerPoints => _hungerPoints;

    private void Awake()
    {
        _movable = GetComponent<IAIMovable>();
        _eatable = GetComponent<IAIEatable>();
        _attackable = GetComponent<IAIAttackable>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();

        _stateMachine = new StateMachine();
        _statsService = new StatsService();

        var idle = new Idle(this, _movable, _aiDestinationSetter);
        var findFood = new FindFood(this, _eatable ,_aiDestinationSetter);

        AddTransition(idle, findFood, NeedFood);
        AddTransition(findFood, idle, CanIdle);

        bool NeedFood() => _hungerPoints <= 60;  
        bool CanIdle() => _hungerPoints > 60 || _eatable.CurrentFoodTarget == null;
       
        
        _stateMachine.SetState(idle);
    }

    private void Start()
    {
        _hungerPoints = MAX_HUNGER_POINTS;
    }

    private void Update()
    {
        _stateMachine.Tick();
        _statsService.DecreaseValue(ref _hungerPoints, 2, 3, 0);
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
        _eatable.IncreaseHunger += IncreaseHunger;
    }

    private void OnDisable()
    {
        _eatable.IncreaseHunger -= IncreaseHunger;
    }
}
