using UnityEngine;

public class UnitHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _healthPoints;
    
    private IDamagable _damagable;

    public int HealthPoints
    {
        get => _healthPoints;
    }

    private void Start()
    {
        _damagable = GetComponent<IDamagable>();
        _damagable.ApplyDamage += DecreaseHealth;
    }

    public void IncreaseHealth(int increaseValue)
    {
        _healthPoints += increaseValue;
    }

    public void DecreaseHealth(int decreaseValue)
    {
        _healthPoints -= decreaseValue;
    }

    public void Modify(int value)
    {
        _healthPoints += value;
    }

    private void OnDisable()
    {
        _damagable.ApplyDamage -= DecreaseHealth;
    }
}
