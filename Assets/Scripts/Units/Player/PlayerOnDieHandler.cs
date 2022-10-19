using UnityEngine;

public class PlayerOnDieHandler : MonoBehaviour
{
    private PlayerDamageHandler _playerDamageHandler;
    private IAbstractFactory _abstractFactory;

    private void Start()
    {
        _playerDamageHandler = GetComponent<PlayerDamageHandler>();
        
        _playerDamageHandler.OnDied += OnDie;
    }

    public void Construct(IAbstractFactory abstractFactory)
    {
        _abstractFactory = abstractFactory;
    }

    private void OnDie()
    {
        DestroyInstance();
    }

    private void DestroyInstance()
    {
        _abstractFactory.DestroyInstance(gameObject);
    }

    private void OnDisable()
    {
        _playerDamageHandler.OnDied -= OnDie;
    }
}
