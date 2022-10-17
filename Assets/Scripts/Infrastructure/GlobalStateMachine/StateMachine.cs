using System;
using System.Collections.Generic;
using System.Threading.Tasks;


public class StateMachine<TContext>
{
    public readonly Dictionary<Type, BaseState<TContext>> States;

    public readonly float TickRate = 0;

    public BaseState<TContext> CurrentState { get; private set; }

    protected TContext Context;

    public StateMachine(TContext context, params BaseState<TContext>[] states)
    {
        Context = context;

        States = new Dictionary<Type, BaseState<TContext>>(states.Length);

        foreach (var state in states)
        {
            States.Add(state.GetType(), state);
        }
        
        TickAsync();
    }

    public void SwitchState<TState>() where TState : State<TContext>
    {
        CurrentState?.Exit();

        TState newState = GetState<TState>();

        CurrentState = newState;
        
        newState?.Enter();
    }
    
    public void SwitchState<TState, T0>(T0 arg0) where TState : StateOneParam<TContext, T0>
    {
        CurrentState?.Exit();

        TState newState = GetState<TState>();
        
        CurrentState = newState;
        
        newState.Enter(arg0);
    }
    
    public void SwitchState<TState, T0, T1>(T0 arg0, T1 arg1) where TState : StateTwoParams<TContext, T0, T1>
    {
        CurrentState?.Exit();

        TState newState = GetState<TState>();
        
        CurrentState = newState;
        
        newState.Enter(arg0, arg1);
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

    private TState GetState<TState>() where TState : BaseState<TContext>
    {
        return States[typeof(TState)] as TState;
    }
}