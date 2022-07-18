using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProieSauvage : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;

    private void OnCollisionEnter2D(Collision2D other)
    {
        ListProie.Instance.isProie(gameObject);
    }
}