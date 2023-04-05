using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersSpawner : MonoBehaviour
{
    public Levels Levelss;
}

[CreateAssetMenu(menuName = "12", fileName = "1")]
public class CustomerSO : ScriptableObject
{
    
}

[Serializable]
public class Level
{
    public int LevelID;

    public List<CustomerSO> CustomerSo;
}


[CreateAssetMenu(menuName = "1", fileName = "2")]
public class Levels : ScriptableObject
{
    public List<Level> Levelss;
}
