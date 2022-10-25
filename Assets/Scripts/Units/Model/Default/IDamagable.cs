using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    GameObject GameObject { get; }
    public event UnityAction<int> ApplyDamage;
    public event UnityAction<IDamagable> OnDied;
    public GameObject Attacker { get; }
    public void TryApplyDamage(int damage, GameObject attacker);
}
