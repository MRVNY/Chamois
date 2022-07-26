using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// classe qui stock les données pour le chamois
///</summary>

[Serializable]
public class DataStorer
{
    public static DataStorer currentDS;
    public Hashtable h;

    public DataStorer()
    {
        currentDS = this;
        h = new Hashtable();
    }
}
