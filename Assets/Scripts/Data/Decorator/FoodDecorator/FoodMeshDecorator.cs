using UnityEngine;

public class FoodMeshDecorator : FoodDecorator
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private float _recoveryValue;
    
    public override void Decorate(ref FoodStats sourceStats)
    {
        sourceStats.Mesh = _mesh;
        sourceStats.RecoveryValue += _recoveryValue;
    }
}
