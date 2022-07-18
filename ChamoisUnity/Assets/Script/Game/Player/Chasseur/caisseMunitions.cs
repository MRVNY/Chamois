using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caisseMunitions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (Global.Personnage == "Chasseur")
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<Munitions>().recupereMunitions();
            }  
        }
    }
    
}
