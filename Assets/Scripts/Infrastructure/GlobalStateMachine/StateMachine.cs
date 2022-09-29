using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StateMachine<TContext>
{
    public StateMachine(TContext context, params State<TContext>[] states)
    {
        Context = context;

        States = new Dictionary<Type, State<TContext>>(states.Length);

        foreach (var state in states)
        {
            States.Add(state.GetType(), state);
        }
        
        TickAsync();
    }

    public readonly Dictionary<Type, State<TContext>> States;

    public readonly float TickRate = 0;

    public State<TContext> CurrentState { get; private set; }

    protected TContext Context;

    public void SwitchState<TState>() where TState : State<TContext>
    {
        CurrentState?.Exit();

        TState newState = GetState<TState>();

        CurrentState = newState;
        
        CurrentState?.Enter();
    }

    private async void TickAsync()
    {
        while (true)
        {
            if (TickRate == 0)
            {
                await Task.Yield();
            }
            else
            {
                await Task.Delay((int)(TickRate * 1000));
            }
            
            CurrentState?.Tick();
        }
    }

    private TState GetState<TState>() where TState : State<TContext>
    {
        return States[typeof(TState)] as TState;
    }
}