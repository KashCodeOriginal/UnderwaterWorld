using UnityEngine;

public class SimpleSpike : MonoBehaviour, IConnectableModule
{
    private IAttackable _attackable;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IDamagable damagable))
        {
            _attackable.TryAttack(damagable);
        }
    }

    public void Construct(IAttackable attackable)
    {
        _attackable = attackable;
    }
}