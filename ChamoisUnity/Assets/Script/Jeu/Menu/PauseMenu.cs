using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Windows.Forms;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject joystick = null;
    [SerializeField] private GameObject boutonTir = null;

    [SerializeField] private GameObject notifRegroup = null;
    [SerializeField] private GameObject notifEncy = null;
    private bool notifActive;

    private void Start()
    {
        joystick = GOPointer.JoystickCanvas;
        //boutonTir = GOPointer.;
    }

    public void Pause()
    {
        SaveLoad.SaveState();
        Time.timeScale = 0;
        Global.pause = true;
        
        GOPointer.JoystickCanvas.SetActive(false);
        boutonTir.SetActive(false);

        // Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        // Debug.Log("notifActive : " + notifActive);

        if (notifRegroup.activeSelf == true)
        {
            notifRegroup.SetActive(false);
            notifEncy.SetActive(false);
            notifActive = true;
        }

        // Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        // Debug.Log("notifActive : " + notifActive);
        
        

    }

    public void Resume()
    {
        Time.timeScale = 1;
        Global.pause = false;
        
        // Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        // Debug.Log("notifActive : " + notifActive);

        if (notifActive == true)
        {
            notifRegroup.SetActive(true);
            notifEncy.SetActive(true);
            notifActive = false;
        }
        
        // Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        // Debug.Log("notifActive : " + notifActive);

        joystick.SetActive(true);
        boutonTir.SetActive(true);
    }
}
