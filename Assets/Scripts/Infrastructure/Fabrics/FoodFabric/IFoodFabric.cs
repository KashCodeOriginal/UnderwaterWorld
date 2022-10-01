using UnityEngine;

public interface IFoodFabric : IFoodInfo
{
    public GameObject CreateObject(Vector3 position, params FoodDecorator[] decorators);
    public void DestroyInstance();
    public void DestroyAllInstances();
}

