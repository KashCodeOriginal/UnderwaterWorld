using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEat : MonoBehaviour, IEatable, IAIEatable
{
    public event UnityAction<int> IncreaseHunger; 

    private Enemy _enemy;
    
    private UnitTriggers _enemyTriggers;

    private IStatsService _statsService;
    
    private Transform _currentFoodTarget;

    [SerializeField] private FoodChooseBehavior _foodChoose;

    public Transform CurrentFoodTarget
    {
        get => _currentFoodTarget;
    }

    public FoodChooseBehavior FoodChoose
    {
        get => _foodChoose;
    }
    
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTriggers = GetComponent<UnitTriggers>();
        _enemyTriggers.OnFoodEaten += TryIncreaseHunger;
    }

    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter)
    {
        var colliders = Physics.OverlapSphere(_enemy.transform.position, 10);
        
        foreach (var collider in colliders)
        {
            if (aiDestinationSetter.target == _currentFoodTarget)
            {
                return;
            }

            _currentFoodTarget = collider.TryGetComponent(out IFood _) ? collider.transform : null;

            if (_currentFoodTarget != null)
            {
                aiDestinationSetter.target = _currentFoodTarget;
            }
        }
    }

    public void Modify(FoodChooseBehavior foodChoose)
    {
        _foodChoose = foodChoose;
    }

    private void TryIncreaseHunger(int increaseValue)
    {
        if (increaseValue <= 0)
        {
            throw new System.ArgumentOutOfRangeException($"{increaseValue} can't be 0 or less");
        }

        if (_enemy.HungerPoints + increaseValue <= Enemy.MAX_HUNGER_POINTS)
        {
            IncreaseHunger?.Invoke(increaseValue);
        }
        else
        {
            int maxAddableValue = Enemy.MAX_HUNGER_POINTS - _enemy.HungerPoints;

            IncreaseHunger?.Invoke(maxAddableValue);
        }
    }

    private void OnDisable()
    {
        _enemyTriggers.OnFoodEaten -= TryIncreaseHunger;
    }
}
