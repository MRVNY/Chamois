using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public static void vibration()
    {
        if(PlayerPrefs.GetInt("vibrations") == 1)
        {
            // TC: à réactiver pour compilation smartphone
            //Handheld.Vibrate();  
        }
    }
}
