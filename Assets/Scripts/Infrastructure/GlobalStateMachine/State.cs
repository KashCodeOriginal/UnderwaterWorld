public class State<TContext> : BaseState<TContext>
{
    public State(TContext context) : base(context)
    {
    }
    
    public virtual void Enter() {}
}

public class StateOneParam<TContext, T0> : BaseState<TContext>
{
    public StateOneParam(TContext context) : base(context) { }

    public virtual void Enter(T0 arg0) { }
}

public class StateTwoParams<TContext, T0, T1> : BaseState<TContext>
{
    public StateTwoParams(TContext context) : base(context) { }

    public virtual void Enter(T0 arg0, T1 arg1) { }
}

public class BaseState<TContext>
{
    protected readonly TContext Context;

    public BaseState(TContext context)
    {
        Context = context;
    }
    
    public virtual void Tick() {}
    public virtual void Exit() {}
}