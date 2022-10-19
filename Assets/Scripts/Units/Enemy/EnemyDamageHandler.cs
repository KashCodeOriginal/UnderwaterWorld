using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageHandler : MonoBehaviour, IDamagable
{
    public event UnityAction<int> ApplyDamage;
    public event UnityAction OnDied;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void TryApplyDamage(int damage)
    {
        if (_enemy.HealthPoints - damage <= 0)
        {
            OnDied?.Invoke();
            return;
        }
        
        ApplyDamage?.Invoke(damage);
    }
}
