using UnityEngine;

public class UnitOnDieHandler : MonoBehaviour
{
    private IDamagable _unitDamageHandler;
    private IFactory _factory;

    private void Start()
    {
        _unitDamageHandler = GetComponent<IDamagable>();
        _unitDamageHandler.OnDied += OnDie;
    }

    public void Construct(IFactory factory)
    {
        _factory = factory;
    }

    private void OnDie(IDamagable damagable)
    {
        DestroyInstance();
    }

    private void DestroyInstance()
    {
        _factory.DestroyInstance(gameObject);
    }

    private void OnDisable()
    {
        _unitDamageHandler.OnDied -= OnDie;
    }
}
