using UnityEngine;

public interface IFoodFabric : IFoodInfo
{
    public void CreateObject(Vector3 position, params FoodDecorator[] decorators);
    public void DestroyInstance(GameObject instance);
    public void DestroyAllInstances();
}

