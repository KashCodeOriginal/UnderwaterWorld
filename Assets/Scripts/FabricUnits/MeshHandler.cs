using UnityEngine;

public class MeshHandler : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;

    public void Modify(Mesh mesh, Color color, float size)
    {
        _meshFilter.mesh = mesh;

        _meshFilter.transform.localScale = Vector3.one * size;

        _meshFilter.GetComponent<MeshRenderer>().material.color = color;
    }
}
