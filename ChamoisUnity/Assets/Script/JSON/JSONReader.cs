using UnityEngine;
using System;
using System.Collections;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public ArrayList data = new ArrayList();
    public EncyInfo info;

    void Start()
    {
        EncyInfoList infosInJson = JsonUtility.FromJson<EncyInfoList>(jsonFile.text);

        foreach (EncyInfo encyinfo in infosInJson.encyinfos)
        {
            data.Add(encyinfo);
        }

    }
}