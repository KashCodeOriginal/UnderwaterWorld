using UnityEngine;

[CreateAssetMenu(fileName = "FoodDecoratorConfig", menuName = "Decorators/BaseConfigs/FoodDecoratorConfig")]
public class FoodConfig : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Color _color;
    [SerializeField] private float _size;
    [SerializeField] private int _recoveryValue;
    [SerializeField] private GameObject _prefab;
    
    public Mesh Mesh => _mesh;
    public Color Color => _color;
    public float Size => _size;
    public int RecoveryValue => _recoveryValue;
    public GameObject Prefab => _prefab;
}
