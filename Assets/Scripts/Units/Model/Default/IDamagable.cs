using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    public event UnityAction<int> ApplyDamage;
    public event UnityAction OnDied;
    public GameObject Attacker { get; }
    public void TryApplyDamage(int damage, GameObject attacker);
}
