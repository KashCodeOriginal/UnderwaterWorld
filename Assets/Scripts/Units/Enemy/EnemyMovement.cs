using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour, IMovable, IAIMovable
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    
    [SerializeField] private float _reachedPointDistance;

    private Vector3 _startPosition;
    private Vector3 _roamPosition;

    private GameObject _randomPositionTarget;

    private GameSettings _gameSettings;

    public float Speed { get; private set; }

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

    public void Construct(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
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
        Vector3 position = _startPosition + GenerateRandomDirection() * Random.Range(_minWalkableDistance, _maxWalkableDistance);

        while (position.x >= _gameSettings.MapMaxX || position.x <= _gameSettings.MapMinX || position.z >= _gameSettings.MapMaxZ || position.z <= _gameSettings.MapMinZ)
        {
            position = _startPosition + GenerateRandomDirection() * Random.Range(_minWalkableDistance, _maxWalkableDistance);
        }

        return position;
    }
    private Vector3 GenerateRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f),0 ,Random.Range(-1f, 1f)).normalized;
    }
}
