using UnityEngine;
using Zenject;

public class EnemyEat : MonoBehaviour
{
    [SerializeField] private int _hungerPoints;
    private int _maxHungerPoints = 100;
    
    private EnemyTriggers _enemyTriggers;

    private IStatsService _statsService;
    
    public int HungerPoint => _hungerPoints;
    
    private void Start()
    {
        _enemyTriggers = GetComponent<EnemyTriggers>();
        
        _enemyTriggers.OnFoodEaten += IncreaseHunger;
        
        _hungerPoints = _maxHungerPoints;
    }

    private void Update()
    {
        _statsService.DecreaseValue(ref _hungerPoints, 5, 2, 0);
    }

    [Inject]
    public void Construct(IStatsService statsService)
    {
        _statsService = statsService;
    }
    
    private void IncreaseHunger(int increaseValue)
    {
        if (increaseValue <= 0)
        {
            throw new System.ArgumentOutOfRangeException($"{increaseValue} can't be 0 or less");
        }

        if (_hungerPoints + increaseValue <= _maxHungerPoints)
        {
            _hungerPoints += increaseValue;
        }
        else
        {
            int maxAddableValue = _maxHungerPoints - _hungerPoints;

            _hungerPoints += maxAddableValue;
        }
    }

    private void OnDisable()
    {
        _enemyTriggers.OnFoodEaten -= IncreaseHunger;
    }
}
