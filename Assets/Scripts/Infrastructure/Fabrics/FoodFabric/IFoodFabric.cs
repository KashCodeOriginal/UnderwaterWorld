using UnityEngine;

public interface IFoodFabric : IFoodInfo
{
    GameObject CreateObject(Vector3 position);
}

