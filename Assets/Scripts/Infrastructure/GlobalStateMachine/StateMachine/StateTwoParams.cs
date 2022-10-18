public class StateTwoParams<TContext, T0, T1> : BaseState<TContext>
{
    public StateTwoParams(TContext context) : base(context) { }

    public virtual void Enter(T0 arg0, T1 arg1) { }
}