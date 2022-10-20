using UnityEngine;
using UnityEngine.Events;

public class UnitDamageHandler : MonoBehaviour, IDamagable
{
    public event UnityAction<int> ApplyDamage;
    public event UnityAction OnDied;

    private IHealth _unitHealth;

    private void Start()
    {
        _unitHealth = GetComponent<UnitHealth>();
    }
    
    public void TryApplyDamage(int damage)
    {
        if (_unitHealth.HealthPoints - damage <= 0)
        {
            OnDied?.Invoke();
            return;
        }
        
        ApplyDamage?.Invoke(damage);
    }
}
