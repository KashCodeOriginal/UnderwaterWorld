using UnityEngine;

[CreateAssetMenu(fileName = "FoodDecoratorConfig", menuName = "Decorators/BaseConfigs/FoodDecoratorConfig")]
public class FoodConfig : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Color _color;
    [SerializeField] private float _size;
    [SerializeField] private float _recoveryValue;
    [SerializeField] private GameObject _prefab;
    
    public Mesh Mesh => _mesh;
    public Color Color => _color;
    public float Size => _size;
    public float RecoveryValue => _recoveryValue;
    public GameObject Prefab => _prefab;
}
