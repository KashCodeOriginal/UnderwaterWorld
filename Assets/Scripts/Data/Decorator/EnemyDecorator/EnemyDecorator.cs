using UnityEngine;

public abstract class EnemyDecorator : ScriptableObject
{
    public abstract void Decorate(ref EnemyStats sourceStats);
}
