using System.Collections.Generic;
using UnityEngine;

public interface IAbstactFactoryInfo
{
    public IReadOnlyList<GameObject> Instances { get; }
}
