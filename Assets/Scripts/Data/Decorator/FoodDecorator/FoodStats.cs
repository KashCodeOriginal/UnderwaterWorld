using UnityEngine;

public struct FoodStats
{
    public Mesh Mesh;
    public Color Color;
    public float Size;
    public float RecoveryValue;

    public FoodStats(Mesh mesh, Color color, float size, float recoveryValue)
    {
        Mesh = mesh;
        Color = color;
        Size = size;
        RecoveryValue = recoveryValue;
    }
}
