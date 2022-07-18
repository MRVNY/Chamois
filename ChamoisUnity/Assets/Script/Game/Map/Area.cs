using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private FogOfWar texture;

    void Start()
    {
        texture = GOPointer.FogOfWarCanvas.GetComponentInChildren<FogOfWar>();
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Global.Personnage == "Randonneur")
        {
            texture.rafraichir(this.GetComponent<RectTransform>());
        }
    }
}
