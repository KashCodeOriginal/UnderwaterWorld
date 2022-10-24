using UnityEngine;

public interface INearbyCollidersFind
{
    public Collider FindClosestFoodCollider();
    public Transform FindClosestEatableFood(Collider closestCollider,IFoodRelationService foodRelationService);
    public Collider FindClosestUnitCollider();
}