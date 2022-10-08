using UnityEngine;

public class PlayerEating : MonoBehaviour
{
    [SerializeField] private int _hungerPoints;
    private int _maxHungerPoints = 100;
    
    private PlayerTriggers _playerTriggers;

    private void Start()
    {
        _playerTriggers = GetComponent<PlayerTriggers>();
        
        _playerTriggers.OnFoodEaten += IncreaseHunger;
        
        _hungerPoints = _maxHungerPoints;
    }

    public int HungerPoint => _hungerPoints;
    
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
        _playerTriggers.OnFoodEaten -= IncreaseHunger;
    }
}
