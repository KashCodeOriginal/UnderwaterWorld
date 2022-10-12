using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour, IMoveable, IAIMoveable
{
    [SerializeField] private float _minWalkableX;
    [SerializeField] private float _maxWalkableX;
    [SerializeField] private float _minWalkableZ;
    [SerializeField] private float _maxWalkableZ;

    [SerializeField] private float _mapHeight;

    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    
    [SerializeField] private float _reachedPointDistance;

    private Vector3 _startPosition;
    private Vector3 _roamPosition;

    private GameObject _randomPositionTarget;

    public float Speed { get; private set; }
    
    public float MinWalkableX
    {
        get => _minWalkableX;
    }

    public float MaxWalkableX
    {
        get => _maxWalkableX;
    }

    public float MinWalkableZ
    {
        get => _minWalkableZ;
    }

    public float MaxWalkableZ
    {
        get => _maxWalkableZ;
    }

    public float MapHeight
    {
        get => _mapHeight;
    }

    public float MinWalkableDistance
    {
        get => _minWalkableDistance;
    }

    public float MaxWalkableDistance
    {
        get => _maxWalkableDistance;
    }

    public float ReachedPointDistance
    {
        get => _reachedPointDistance;
    }

    private void Start()
    {
        _startPosition = transform.position;

        _roamPosition = GenerateRoamingPosition();

        _randomPositionTarget = new GameObject();
        _randomPositionTarget.transform.SetParent(gameObject.transform);
        _randomPositionTarget.name = "Target";
    }


    public void MoveToRandomPoint(AIDestinationSetter aiDestinationSetter)
    {
        _randomPositionTarget.transform.position = _roamPosition;

        if (Vector3.Distance(gameObject.transform.position, _roamPosition) < _reachedPointDistance)
        {
            _roamPosition = GenerateRoamingPosition();
        }

        aiDestinationSetter.target = _randomPositionTarget.transform;
    }

    public void Modify(float speed)
    {
        Speed = speed;
    }

    private Vector3 GenerateRoamingPosition()
    {
        return _startPosition + GenerateRandomDirection() * Random.Range(_minWalkableDistance, _maxWalkableDistance);
    }
    private Vector3 GenerateRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f),0 ,Random.Range(-1f, 1f)).normalized;
    }
}
