using UnityEngine;
using UnityEngine.Events;

public class PlayerEat : MonoBehaviour, IEatable
{
    [SerializeField] private FoodChooseBehavior _foodChoose;
    
    private UnitTriggers _unitTriggers;
    private UnitHunger _unitHunger;

    public FoodChooseBehavior FoodChoose
    {
        get => _foodChoose;
    }

    public event UnityAction<int> IncreaseHunger;

    private void Start()
    {
        _unitTriggers = GetComponent<UnitTriggers>();

        _unitHunger = GetComponent<UnitHunger>();
        
        _unitTriggers.OnFoodEaten += TryIncreaseHunger;
    }
    
    
    private void TryIncreaseHunger(int increaseValue)
    {
        if (increaseValue <= 0)
        {
            throw new System.ArgumentOutOfRangeException($"{increaseValue} can't be 0 or less");
        }

        if (_unitHunger.HungerPoints + increaseValue <= UnitHunger.MAX_HUNGER_POINTS)
        {
            IncreaseHunger?.Invoke(increaseValue);
        }
        else
        {
            int maxAddableValue = UnitHunger.MAX_HUNGER_POINTS - _unitHunger.HungerPoints;

            IncreaseHunger?.Invoke(maxAddableValue);
        }
    }

    private void OnDisable()
    {
        _unitTriggers.OnFoodEaten -= TryIncreaseHunger;
    }
}
