using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public static ZoneManager Instance;

    public Hashtable zones = new Hashtable();
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        zones = new Hashtable();
        foreach (var zone in GetComponentsInChildren<Collider2D>())
        {
            zones.Add(zone.gameObject.name, zone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
