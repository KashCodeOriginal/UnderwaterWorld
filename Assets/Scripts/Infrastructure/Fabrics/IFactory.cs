using UnityEngine;

public interface IFactory
{
    public void DestroyInstance(GameObject instance);
    public void DestroyAllInstances();
}
