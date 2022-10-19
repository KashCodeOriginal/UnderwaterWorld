using UnityEngine;

public class Player : MonoBehaviour
{
    public const int MAX_HUNGER_POINTS = 100;
    
    [SerializeField] private int _healthPoints;

    [SerializeField] private int _hungerPoints;


    public int HungerPoints => _hungerPoints;
    public int HealthPoints => _hungerPoints;

    private IEatable _eatable;
    private IDamagable _damagable;

    private void Start()
    {
        _hungerPoints = MAX_HUNGER_POINTS;

        _eatable = GetComponent<IEatable>();
        _damagable = GetComponent<IDamagable>();

        _eatable.IncreaseHunger += IncreaseHunger;
        _damagable.ApplyDamage += DecreaseHealth;
    }

    private void IncreaseHunger(int increaseValue)
    {
        _hungerPoints += increaseValue;
    }

    private void DecreaseHealth(int decreaseValue)
    {
        _healthPoints -= decreaseValue;
    }

    private void OnDisable()
    {
        _eatable.IncreaseHunger -= IncreaseHunger;
        _damagable.ApplyDamage -= DecreaseHealth;
    }
}
