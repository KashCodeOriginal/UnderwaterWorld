using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const int MAX_HUNGER_POINTS = 100;
    
    [SerializeField] private int _health;

    [SerializeField] private int _hungerPoints;


    public int HungerPoint => _hungerPoints;

    private IEatable _eatable;

    private void Start()
    {
        _hungerPoints = MAX_HUNGER_POINTS;

        _eatable = GetComponent<IEatable>();

        _eatable.IncreaseHunger += IncreaseHunger;
    }

    private void IncreaseHunger(int increaseValue)
    {
        _hungerPoints += increaseValue;
    }

    private void OnDisable()
    {
        _eatable.IncreaseHunger -= IncreaseHunger;
    }
}
