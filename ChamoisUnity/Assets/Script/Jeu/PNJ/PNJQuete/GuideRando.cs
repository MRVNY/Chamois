using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using System;
using Newtonsoft.Json.Linq;
using TMPro;

public class GuideRando : MonoBehaviour
{
    //PnJ donneur de randonnées
    public GameObject donneurDeRando2;
    private DataStorerRandonneur dataSt;
    public Boolean randoEnCours;
    public float tpsRando;

    public JObject convoTree;
   
    // Start is called before the first frame update
    EncycloContentRandonneur ency;
    
    public TextAsset jsonFile;
    public TextAsset jsonFileEncy;
    public List<EncyInfo> data2;


    void Start()
    {
        randoEnCours = false;
        tpsRando = 0;

        if (Global.Personnage == "Randonneur")
        {
            dataSt = GOPointer.PlayerRandonneur.GetComponent<DataStorerRandonneur>();

        }

        convoTree = JObject.Parse(jsonFile.text);

        EncyInfoList infosInJson2 = JsonUtility.FromJson<EncyInfoList>(jsonFileEncy.text);
        data2 = new List<EncyInfo>();

        foreach (EncyInfo encyinfo in infosInJson2.encyinfos)
        {
            data2.Add(encyinfo);
        }

        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();

        foreach (GameObject rando in GameObject.Find("Randos").GetComponentsInChildren<GameObject>())
        {
            rando.SetActive(false);
        }

    }

    public void Update()
    {
        if (randoEnCours)
        {
            tpsRando += Time.deltaTime;
        }
    }

}