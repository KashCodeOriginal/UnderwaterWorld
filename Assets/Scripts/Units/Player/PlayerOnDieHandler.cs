using UnityEngine;

public class PlayerOnDieHandler : MonoBehaviour
{
    private IDamagable _playerDamageHandler;
    private IFactory _factory;

    private void Start()
    {
        _playerDamageHandler = GetComponent<IDamagable>();
        
        _playerDamageHandler.OnDied += OnDie;
    }

    public void Construct(IFactory factory)
    {
        _factory = factory;
    }

    private void OnDie()
    {
        DestroyInstance();
    }

    private void DestroyInstance()
    {
        _factory.DestroyInstance(gameObject);
    }

    private void OnDisable()
    {
        _playerDamageHandler.OnDied -= OnDie;
    }
}
