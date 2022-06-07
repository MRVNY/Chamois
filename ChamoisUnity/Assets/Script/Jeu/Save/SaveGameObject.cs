using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class SaveGameObject : MonoBehaviour
{
    GameObject gm;
    public string filename = "fileSave";

    public void Awake()
    {
        gm = gameObject;
    }

    public void Save()
    {
        SaveLoad.Save<GameObject>(gm, filename);
    }
}
