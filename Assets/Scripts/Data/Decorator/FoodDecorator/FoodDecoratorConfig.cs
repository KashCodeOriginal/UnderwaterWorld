using UnityEngine;

[CreateAssetMenu(fileName = "FoodDecoratorConfig", menuName = "Decorators/BaseConfigs/FoodDecoratorConfig")]
public class FoodDecoratorConfig : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Color _color;
    [SerializeField] private float _size;
    [SerializeField] private float _recoveryValue;
    
    public Mesh Mesh => _mesh;
    public Color Color => _color;
    public float Size => _size;
    public float RecoveryValue => _recoveryValue;
}
