using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public TexturePercentage texture;
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Global.Personnage == "Randonneur")
        {
            texture.rafraichir(this.GetComponent<RectTransform>());
        }
    }
}
