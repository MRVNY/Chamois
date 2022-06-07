using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ramasseDechets : MonoBehaviour
{
    public GameObject dechet;
    public int ID;
    public Collider2D dechetCollider;
    // Start is called before the first frame update
    public void Start()
    {
        if (Global.Personnage == "Chasseur")
        {
            dechetCollider.isTrigger = true;
        }
    }

    public void Update()
    {
        if (chasseurDechet.dechetsMain < chasseurDechet.limiteDechetsMain)
        {
            dechetCollider.isTrigger = true;
        }
        else
        {
            dechetCollider.isTrigger = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Global.Personnage == "Chasseur")
        {
            chasseurDechet.dechetsMain++;
            Destroy(dechet);
            chasseurDechet.updateView();
        }
    }
}
