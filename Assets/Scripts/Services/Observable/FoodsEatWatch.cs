using System;
using UnityEngine.Events;
using System.Collections.Generic;

public class FoodsFoodEatWatch : IFoodEatObservable, IDisposable
{
    public event UnityAction<IFood> OnFoodEaten;
    
    private List<IFood> _instances = new List<IFood>();
    public List<IFood> Instances => _instances;

    public void Register(IFood food)
    {
        if (_instances.Contains(food))
        {
            return;
        }
        
        _instances.Add(food);

        food.WasEaten += FoodEaten;
    }

    private void FoodEaten(IFood food)
    {
        OnFoodEaten?.Invoke(food);
    }

    public void Dispose()
    {
        if (_instances.Count < 0)
        {
            return;
        }
        
        foreach (var food in _instances)
        {
            food.WasEaten -= FoodEaten;
        }
    }
}