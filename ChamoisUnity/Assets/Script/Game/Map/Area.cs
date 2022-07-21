using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private FogOfWar texture;

    void Start()
    {
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Global.Personnage == "Randonneur")
        {
            FogOfWar.Instance.rafraichir(this.GetComponent<RectTransform>());
        }
    }
}
