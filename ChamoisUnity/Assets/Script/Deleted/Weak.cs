using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT HAS BEEN REMOVED FROM THE GAME, BUT KEPT FOR OTHER DEPRECATED PREFABS

public class Weak : MonoBehaviour
{
    
    // Start is called before the first frame update
    private int id;
    void Start()
    {
        id = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if(other.collider.CompareTag("Bullet"))
        //     GOPointer.ListeChamoisSauvages.GetComponent<ListChamois>().isProie(gameObject);
    }
}
