using System;
using UnityEngine;
using UnitsStateMachine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private int _check;
    
    private void Awake()
    {
        var _movement = GetComponent<IMoveable>();
        var _attack = GetComponent<IAttackable>();
        var _eat = GetComponent<IEatable>();

        _stateMachine = new StateMachine();

        var idle = new Idle(this, _movement);
        var eat = new Eat();
        
        At(idle, eat, HasTarget);

        bool HasTarget() => _check == 0;

        _stateMachine.SetState(idle);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    public void Modify(int health)
    {
        _health += health;
    }

    private StateMachine _stateMachine;

    public int Health => _health;

    private void At(State from, State to, Func<bool> condition)
    {
        _stateMachine.AddTransition(from, to, condition);
    }
}
