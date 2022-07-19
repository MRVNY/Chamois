using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;

    public GameObject MapChamois;
    public GameObject MapChasseur;
    public GameObject MapRando;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        MapChamois.SetActive(false);
        MapChasseur.SetActive(false);
        MapRando.SetActive(false);

        switch (Global.Personnage)
        {
            case "Chamois":
                MapChamois.SetActive(true);
                break;
            case "Chasseur":
                MapChasseur.SetActive(true);
                break;
            case "Randonneur":
                MapRando.SetActive(true);
                break;
        }
    }
}
