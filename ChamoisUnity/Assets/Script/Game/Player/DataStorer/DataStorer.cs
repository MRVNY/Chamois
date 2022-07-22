using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// classe qui stock les données pour le chamois
///</summary>

[Serializable]
public class DataStorer : MonoBehaviour
{
    public static DataStorer currentDS;
    protected Hashtable h;

    protected void Start()
    {
        currentDS = this;
        h = new Hashtable();
    }
}
