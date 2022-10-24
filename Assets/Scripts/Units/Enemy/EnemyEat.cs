using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEat : MonoBehaviour, IAIEatable
{
    public event UnityAction<int> IncreaseHunger;

    [SerializeField] private FoodChooseBehavior _foodChoose;
    
    private IHunger _enemyHunger;

    private UnitTriggers _enemyTriggers;

    private IStatsService _statsService;

    private Transform _currentTarget;

    private IFoodRelationService _foodRelationService;

    private INearbyCollidersFind _nearbyCollidersFind;

    public Transform CurrentTarget
    {
        get => _currentTarget;
    }

    public FoodChooseBehavior FoodChoose
    {
        get => _foodChoose;
    }
    
    private void Start()
    {
        _enemyHunger = GetComponent<IHunger>();
        _enemyTriggers = GetComponent<UnitTriggers>();
        _nearbyCollidersFind = GetComponent<INearbyCollidersFind>();

        _foodRelationService = _enemyTriggers._foodRelationService;
        
        _enemyTriggers.OnFoodEaten += TryIncreaseHunger;
    }

    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter)
    {
        if (aiDestinationSetter.target == _currentTarget)
        {
            return;
        }

        var closestFoodCollider = _nearbyCollidersFind.FindClosestFoodCollider();

        if (closestFoodCollider != null)
        {
            _currentTarget = _nearbyCollidersFind.FindClosestEatableFood(closestFoodCollider, _foodRelationService);
            
            if (_currentTarget != null)
            {
                aiDestinationSetter.target = _currentTarget;
            }
        }
        else
        {
            if (_foodChoose != FoodChooseBehavior.Herbivorous)
            { 
                var closestUnitCollider = _nearbyCollidersFind.FindClosestUnitCollider();

                if (closestUnitCollider != null)
                {
                    _currentTarget = closestUnitCollider.transform;
                    aiDestinationSetter.target = _currentTarget;
                }
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

        if (_enemyHunger.HungerPoints + increaseValue <= UnitHunger.MAX_HUNGER_POINTS)
        {
            IncreaseHunger?.Invoke(increaseValue);
        }
        else
        {
            int maxAddableValue = UnitHunger.MAX_HUNGER_POINTS - _enemyHunger.HungerPoints;

            IncreaseHunger?.Invoke(maxAddableValue);
        }
    }

    private void OnDisable()
    {
        _enemyTriggers.OnFoodEaten -= TryIncreaseHunger;
    }
}
