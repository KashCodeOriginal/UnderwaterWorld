using UnityEngine;

public struct FoodStats
{
    public Mesh Mesh;
    public Color Color;
    public float Size;
    public int RecoveryValue;
    public FoodTypeBehavior FoodType;
    
    public FoodStats(Mesh mesh, Color color, float size, int recoveryValue, FoodTypeBehavior foodType)
    {
        Mesh = mesh;
        Color = color;
        Size = size;
        RecoveryValue = recoveryValue;
        FoodType = foodType;
    }
}
