using UnityEngine;

public class DestroyOnEat : MonoBehaviour
{
    private IFoodFactory _foodFactory;
    
    public void Construct(IFoodFactory foodFactory)
    {
        _foodFactory = foodFactory;
    }
    
    
}
