using UnityEngine;

public interface IFoodFactory : IFoodInfo
{
    public void CreateObject(Vector3 position, params FoodDecorator[] decorators);
    public void DestroyInstance(GameObject instance);
    public void DestroyAllInstances();
}

