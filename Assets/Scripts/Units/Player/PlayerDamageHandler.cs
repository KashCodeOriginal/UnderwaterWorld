using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageHandler : MonoBehaviour, IDamagable
{
    public event UnityAction<int> ApplyDamage;
    public event UnityAction OnDied;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    
    public void TryApplyDamage(int damage)
    {
        if (_player.HealthPoints - damage <= 0)
        {
            OnDied?.Invoke();
            return;
        }
        
        ApplyDamage?.Invoke(damage);
    }
}
