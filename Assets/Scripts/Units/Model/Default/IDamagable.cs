using UnityEngine.Events;

public interface IDamagable
{
    public event UnityAction<int> ApplyDamage;
    public event UnityAction OnDied;
    public void TryApplyDamage(int damage);
}
