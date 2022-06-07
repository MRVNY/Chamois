using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchPlayerMap : MonoBehaviour
{
    public Boolean isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    void Update()
    {
        Debug.Log(isActive);
    }

    public void Switch()
    {
        GameEvents.onSwitchCamera();
        isActive = !isActive;
        GameEvents.onPause();
    }
}
