using UnityEngine;

public interface IFoodFactory : IFoodInfo, IFactory
{
    public void CreateObject(Vector3 position, params FoodDecorator[] decorators);
    
}

