using UnityEngine;
using UnityEngine.Events;

public class UnitDamageHandler : MonoBehaviour, IDamagable
{
    public GameObject GameObject => gameObject;
    public event UnityAction<int> ApplyDamage;
    public event UnityAction<IDamagable> OnDied;
    
    public GameObject Attacker { get; private set; }

    private IHealth _unitHealth;

    private IAIMovable _enemyMovement;


    private void Start()
    {
        _unitHealth = GetComponent<IHealth>();

        if (TryGetComponent(out IAIMovable aiMovable))
        {
            _enemyMovement = aiMovable;
            
            _enemyMovement.IsUnitEscaped += UnitEscaped;
        }
    }

    public void TryApplyDamage(int damage, GameObject attacker)
    {
        if (_unitHealth.HealthPoints - damage <= 0)
        {
            OnDied?.Invoke(this);
            return;
        }
        
        ApplyDamage?.Invoke(damage);

        Attacker = attacker;
    }

    private void UnitEscaped()
    {
        Attacker = null;
    }

    private void OnDisable()
    {
        if (_enemyMovement != null)
        {
            _enemyMovement.IsUnitEscaped -= UnitEscaped;
        }
    }
}
