using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    /*public GameObject zone1;
   public GameObject zone2;*/

    public int difficulty = 2;

    private bool isSlope;

    public static bool sliding;
    /*PolygonCollider2D z1;
    PolygonCollider2D z2;*/

    private void Awake()
    {
        isSlope = this.GetComponent<PolygonCollider2D>().isTrigger;
    }
    
    public void OnEnable()
    {
        if (Global.Personnage != "Chamois")
        {
            this.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
        else
        {
            this.GetComponent<PolygonCollider2D>().isTrigger = isSlope;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && (Global.Personnage == "Chamois"))
        {
            sliding = true;
            Global.difficulty = difficulty;
            //collider.GetComponentInParent<Rigidbody2D>().velocity = Vector2.down * difficulty;
        }
        // else (collider.transform.parent.CompareTag("Player"))
        // {
        //     Rocks.sliding = false;
        // }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        sliding = false;
    }
}
