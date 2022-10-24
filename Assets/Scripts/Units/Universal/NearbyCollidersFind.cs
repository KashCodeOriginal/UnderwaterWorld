using UnityEngine;

public class NearbyCollidersFind : MonoBehaviour, INearbyCollidersFind
{
    [SerializeField] private int _radius;

    public Collider FindClosestFoodCollider()
    {
        var colliders = FindCollidersAroundUnit();
        
        Collider minDistanceCollider = null;
        var minDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IFood _))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < minDistance)
                {
                    minDistanceCollider = collider;
                    minDistance = distance;
                }
            }
        }

        return minDistanceCollider;
    }
    
    public Collider FindClosestUnitCollider()
    {
        var colliders = FindCollidersAroundUnit();
        
        Collider minDistanceCollider = null;
        var minDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable _) && collider.gameObject != gameObject)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < minDistance )
                {
                    minDistanceCollider = collider;
                    minDistance = distance;
                }
            }
        }

        return minDistanceCollider;
    }

    public Transform FindClosestEatableFood(Collider closestCollider ,IFoodRelationService foodRelationService)
    {
        if (gameObject.TryGetComponent(out IEatable eatable))
        {
            var foodTypes = foodRelationService.GetEatableFoodType(eatable.FoodChoose);

            var food = closestCollider.GetComponent<IFood>();

            foreach (var foodType in foodTypes)
            {
                if (foodType == food.FoodType)
                {
                    return closestCollider.transform;
                }
            }
        }

        return null;
    }

    private Collider[] FindCollidersAroundUnit()
    {
        var enemyPosition = gameObject.transform.position;
        
        var colliders = Physics.OverlapSphere(enemyPosition, _radius);

        return colliders;
    }
}