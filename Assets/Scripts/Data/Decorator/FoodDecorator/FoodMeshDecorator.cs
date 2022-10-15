using UnityEngine;

[CreateAssetMenu(fileName = "FoodMeshDecorator", menuName = "Decorators/FoodDecorators/FoodMeshDecorator")]
public class FoodMeshDecorator : FoodDecorator
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private int _recoveryValue;
    [SerializeField] private FoodTypeBehavior _foodType;
    
    public override void Decorate(ref FoodStats sourceStats)
    {
        sourceStats.Mesh = _mesh;
        sourceStats.RecoveryValue += _recoveryValue;
        sourceStats.FoodType = _foodType;
    }
}
