using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButtons : MonoBehaviour
{

    public static GameObject Instanace;
    public GameObject talk;
    public GameObject recharge;
    public GameObject validate;

    private void Awake()
    {
        if(Instanace == null)
        {
            Instanace = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
