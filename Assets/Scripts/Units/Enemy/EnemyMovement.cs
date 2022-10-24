using Pathfinding;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour, IAIMovable
{
    public event UnityAction IsUnitEscaped;
    
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    
    [SerializeField] private float _reachedPointDistance;

    [SerializeField] private float _safetyDistanceFromAttacker;

    private Vector3 _startPosition;
    private Vector3 _roamPosition;
    
    private Vector3 _movingAwayPosition = Vector3.zero;

    private GameObject _randomPositionTarget;

    private GameSettings _gameSettings;

    public float Speed { get; private set; }

    public float MinWalkableDistance => _minWalkableDistance;

    public float MaxWalkableDistance => _maxWalkableDistance;

    public float ReachedPointDistance => _reachedPointDistance;

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
    
    public void MoveAwayFromAttacker(AIDestinationSetter aiDestinationSetter, Transform attackerPosition)
    {
        if (Vector3.Distance(gameObject.transform.position, attackerPosition.position) < _safetyDistanceFromAttacker)
        {
            if (_movingAwayPosition == Vector3.zero)
            {
                _movingAwayPosition = GenerateRoamingPosition(attackerPosition);
            }
            
            _randomPositionTarget.transform.position = new Vector3(_movingAwayPosition.x, 0, _movingAwayPosition.z);
            
            if (Vector3.Distance(gameObject.transform.position,  _randomPositionTarget.transform.position) < _reachedPointDistance)
            {
                _movingAwayPosition = GenerateRoamingPosition(attackerPosition);
            }

            aiDestinationSetter.target = _randomPositionTarget.transform;
            
            return;
        }
        
        _movingAwayPosition = Vector3.zero;
        IsUnitEscaped?.Invoke();
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
    
    private Vector3 GenerateRoamingPosition(Transform attackerPosition)
    {
        Vector3 position = _startPosition + GenerateDefinedDirection(attackerPosition) * Random.Range(_minWalkableDistance, _maxWalkableDistance);

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

    private Vector3 GenerateDefinedDirection(Transform attacker)
    {
        var direction = gameObject.transform.position - attacker.position;
        return direction.normalized;
    }
}
