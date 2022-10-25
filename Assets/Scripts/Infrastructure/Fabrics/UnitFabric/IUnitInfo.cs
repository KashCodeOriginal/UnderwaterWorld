using System;
using UnityEngine;
using System.Collections.Generic;

public interface IUnitInfo
{
    public event Action OnInstancesListChanged;
    public IReadOnlyList<GameObject> Instances { get; }
}
