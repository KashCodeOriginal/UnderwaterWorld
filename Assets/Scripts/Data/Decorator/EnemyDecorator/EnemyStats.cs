using UnityEngine;

public struct EnemyStats
{
    public int Health;
    public int Damage;
    public float Size;
    public float Speed;
    public Mesh Mesh;
    public FoodChooseBehavior[] FoodChoose;

    public EnemyStats(int health, int damage, float size, float speed, Mesh mesh, FoodChooseBehavior[] foodChoose)
    {
        Health = health;
        Damage = damage;
        Size = size;
        Speed = speed;
        Mesh = mesh;
        FoodChoose = foodChoose;
    }
}