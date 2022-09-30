using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneInfoService : IService
{
  public string CurrentSceneName { get; }  
}
