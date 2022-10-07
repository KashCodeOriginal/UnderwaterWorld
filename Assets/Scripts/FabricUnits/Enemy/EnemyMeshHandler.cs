using UnityEngine;

public class EnemyMeshHandler : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;

    public void Modify(Mesh mesh, float size)
    {
        _meshFilter.mesh = mesh;
        
        _meshFilter.transform.localScale = Vector3.one * size;
    }
}
