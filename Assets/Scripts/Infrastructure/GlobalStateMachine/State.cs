public class State<TContext>
{
    protected readonly TContext Context;

    public State(TContext context)
    {
        Context = context;
    }

    public virtual void Enter(){}
    public virtual void Tick(){}
    public virtual void Exit(){}
}