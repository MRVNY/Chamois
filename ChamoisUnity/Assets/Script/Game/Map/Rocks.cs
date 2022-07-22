using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paroisRocheuses2 : MonoBehaviour
{
    /*public GameObject zone1;
   public GameObject zone2;*/

    public int difficulty = 2;

    /*PolygonCollider2D z1;
    PolygonCollider2D z2;*/

    void Start()
    {
        if (Global.Personnage != "Chamois")
        {
            this.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }
    
    void Update()
    {
        //foreach (var x in zones)
        /*for (int i = 0; i < zones.Count; i++)
        {
            z = zones[i].GetComponent<PolygonCollider2D>();
        }*/
        /*z1 = zone1.GetComponent<PolygonCollider2D>();
        z2 = zone2.GetComponent<PolygonCollider2D>();*/
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && (Global.Personnage == "Chamois"))
        {
            Global.sliding = true;
            Global.difficulty = difficulty;
            //collider.GetComponentInParent<Rigidbody2D>().velocity = Vector2.down * difficulty;
        }
        // else (collider.transform.parent.CompareTag("Player"))
        // {
        //     Global.sliding = false;
        // }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Global.sliding = false;
    }
}
