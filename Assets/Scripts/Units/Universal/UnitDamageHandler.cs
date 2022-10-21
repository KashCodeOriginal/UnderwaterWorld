using UnityEngine;
using UnityEngine.Events;

public class UnitDamageHandler : MonoBehaviour, IDamagable
{
    public event UnityAction<int> ApplyDamage;
    public event UnityAction OnDied;
    
    public GameObject Attacker { get; private set; }

    private IHealth _unitHealth;


    private void Start()
    {
        _unitHealth = GetComponent<IHealth>();
    }

    public void TryApplyDamage(int damage, GameObject attacker)
    {
        if (_unitHealth.HealthPoints - damage <= 0)
        {
            OnDied?.Invoke();
            return;
        }
        
        ApplyDamage?.Invoke(damage);

        Attacker = attacker;
    }
}
