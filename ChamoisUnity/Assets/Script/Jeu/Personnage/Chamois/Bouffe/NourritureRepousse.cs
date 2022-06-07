using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NourritureRepousse : MonoBehaviour
{
   // public static NourritureRepousse current;
    public float tempsRepousse = 10f;
    public float tempsActuel = 0f;

    public static System.Action onTimeToGrowTrigger;

    void Start()
    {
        GameEvents.Pause += Pause;
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.Personnage == "Chamois")
        {
            tempsActuel += Time.deltaTime;
            if (tempsActuel >= tempsRepousse)
            {
                onTimeToGrowTrigger();
                tempsActuel = 0f;
            }
        }
    }

    void Pause()
    {
        enabled = !enabled;
    }
    

}
