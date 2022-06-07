using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class paroisRocheuse : MonoBehaviour
{
    /*public GameObject zone1;
    public GameObject zone2;*/
    public List<GameObject> zones = new List<GameObject>();

    public int difficulté;

    /*PolygonCollider2D z1;
    PolygonCollider2D z2;*/
    PolygonCollider2D z;

    void Start()
    {
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < zones.Count; i++)
        {
            if ( /*(collider == z1) || (collider == z2)*/ (collider == zones[i].GetComponent<PolygonCollider2D>()))
            {
                Debug.Log("in");
                GOPointer.PlayerChamois.GetComponent<JoueurChamois>().vitesse -= 2;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        for (int i = 0; i < zones.Count; i++)
        {
            if ( /*(collider == z1) || (collider == z2)*/ collider == zones[i].GetComponent<PolygonCollider2D>())
            {
                Debug.Log("out");
                GOPointer.PlayerChamois.GetComponent<JoueurChamois>().vitesse += 2;
            }
        }
    }
}