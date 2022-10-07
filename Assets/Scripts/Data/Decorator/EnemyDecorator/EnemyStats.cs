using UnityEngine;

public struct EnemyStats
{
    public int Health;
    public int Damage;
    public float Size;
    public float Speed;
    public Mesh Mesh;

    public EnemyStats(int health, int damage, float size, float speed, Mesh mesh)
    {
        Health = health;
        Damage = damage;
        Size = size;
        Speed = speed;
        Mesh = mesh;
    }
}
