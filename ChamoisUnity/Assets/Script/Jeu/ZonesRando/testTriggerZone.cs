using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testTriggerZone : MonoBehaviour
{

    public GameObject bien;
    public GameObject mal;

    PolygonCollider2D cb;
    PolygonCollider2D cm;

    void Start()
    {
        cb = bien.GetComponent<PolygonCollider2D>();
        cm = mal.GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == cb)
        {
            Debug.Log("Bonne zone");
            
        }
        else if (collider == cm)
        {
            Debug.Log("Mauvaise zone");
        }


        /*switch (collider)
        {
            case (cb):
                Debug.Log(goodZone())
        }*/
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
    }

    private bool goodZone(Collider2D collider)
    {
        return collider == cb;
    }
}