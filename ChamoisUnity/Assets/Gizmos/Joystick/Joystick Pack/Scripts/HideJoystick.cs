using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideJoystick : MonoBehaviour
{
    
    public GameObject g;
    public void cache()
    {
        g.SetActive(false);
    }
}
