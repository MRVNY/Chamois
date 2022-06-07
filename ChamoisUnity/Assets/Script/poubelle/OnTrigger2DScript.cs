using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnTrigger2DScript : MonoBehaviour
{
    public string tagDetection;

    public bool estDedans = false;
    
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(tagDetection))
            Stress.instance.danger(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(tagDetection))
            Stress.instance.danger(false);
    }*/
}
