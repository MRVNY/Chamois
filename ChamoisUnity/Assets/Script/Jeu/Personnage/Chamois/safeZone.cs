using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// classe pour les zone safe du Chamois
///</summary>
public class safeZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameEvents.onSaveInitiated();
    }
}
