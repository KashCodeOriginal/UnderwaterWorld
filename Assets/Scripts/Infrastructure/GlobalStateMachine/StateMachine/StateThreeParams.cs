public class StateThreeParams<TContext, T0, T1, T2> : BaseState<TContext>
{
    public StateThreeParams(TContext context) : base(context) { }
    
    public virtual void Enter(T0 arg0, T1 arg1, T2 arg2) { }
}