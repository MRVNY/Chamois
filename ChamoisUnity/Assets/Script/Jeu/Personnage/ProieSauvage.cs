using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProieSauvage : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Find("proies").GetComponent<ListProie>().isProie(gameObject);
    }
}