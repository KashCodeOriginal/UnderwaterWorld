using System;
using UnityEngine;

public class EnemyOnDieHandler : MonoBehaviour
{
    private EnemyDamageHandler _enemyDamageHandler;
    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyDamageHandler = GetComponent<EnemyDamageHandler>();

        _enemyDamageHandler.OnDied += OnDie;
    }

    public void Construct(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void OnDie()
    {
        DestroyInstance();
    }

    private void DestroyInstance()
    {
        _enemyFactory.DestroyInstance(gameObject);
    }

    private void OnDisable()
    {
        _enemyDamageHandler.OnDied -= OnDie;
    }
}
