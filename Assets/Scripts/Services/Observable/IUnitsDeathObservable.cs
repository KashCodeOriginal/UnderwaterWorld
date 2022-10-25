using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public interface IUnitsDeathObservable
{
    public event UnityAction<IDamagable> OnUnitDied;
    public List<IDamagable> Instances { get; }
    public void Register(IDamagable instance);
}
