using System;
using UnityEngine.Events;
using System.Collections.Generic;

public class UnitsUnitsDeathWatch : IUnitsDeathObservable, IDisposable
{
    public event UnityAction<IDamagable> OnUnitDied;
    
    private List<IDamagable> _instances = new List<IDamagable>();
    public List<IDamagable> Instances => _instances;

    public void Register(IDamagable damagable)
    {
        if (_instances.Contains(damagable))
        {
            return;
        }
        
        _instances.Add(damagable);

        damagable.OnDied += UnitDied;
    }

    private void UnitDied(IDamagable damagable)
    {
        OnUnitDied?.Invoke(damagable);
    }

    public void Dispose()
    {
        if (_instances.Count < 0)
        {
            return;
        }
        
        foreach (var instance in _instances)
        {
            instance.OnDied -= UnitDied;
        }
    }
}