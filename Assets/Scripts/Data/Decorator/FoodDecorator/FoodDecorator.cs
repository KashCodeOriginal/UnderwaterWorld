using UnityEngine;

public abstract class FoodDecorator : ScriptableObject
{
    public abstract void Decorate(ref FoodStats sourceStats);
}
