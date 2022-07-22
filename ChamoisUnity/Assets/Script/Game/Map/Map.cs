using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject MainMap;
    public static Map Instance;

    public Color green;
    public Color blue;
    public Color orange;
    
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

    public void ChangeColor()
    { 
        Color currentColor = Color.white;

        switch (Global.Personnage)
        {
            case "Chamois":
                currentColor = green;
                break;
            case "Chasseur":
                currentColor = orange;
                break;
            case "Randonneur":
                currentColor = blue;
                break;
        }

        foreach (var img in MainMap.GetComponentsInChildren<Image>(true))
        {
            img.color = currentColor;
        }
    }
}
