using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Windows.Forms;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject joystick = null;
    [SerializeField] private GameObject iconeEncyclopedie = null;
    [SerializeField] private GameObject iconeCarte = null;
    [SerializeField] private GameObject iconeRegroupement = null;
    [SerializeField] private GameObject iconePause = null;
    [SerializeField] private GameObject iconeHautFait = null;
    [SerializeField] private GameObject boutonTir = null;

    [SerializeField] private GameObject notifRegroup = null;
    [SerializeField] private GameObject notifEncy = null;
    private bool notifActive;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        joystick.SetActive(false);
        iconeEncyclopedie.SetActive(false);
        iconeCarte.SetActive(false);
        boutonTir.SetActive(false);
        iconeRegroupement.SetActive(false);
        iconePause.SetActive(false);
        iconeHautFait.SetActive(false);
        Time.timeScale = 0f;

        Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        Debug.Log("notifActive : " + notifActive);

        if (notifRegroup.activeSelf == true)
        {
            notifRegroup.SetActive(false);
            notifEncy.SetActive(false);
            notifActive = true;
        }

        Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        Debug.Log("notifActive : " + notifActive);

    }

    public void Resume()
    {
        Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        Debug.Log("notifActive : " + notifActive);

        if (notifActive == true)
        {
            notifRegroup.SetActive(true);
            notifEncy.SetActive(true);
            notifActive = false;
        }

        Debug.Log("notifRegroup : " + notifRegroup.activeSelf);
        Debug.Log("notifActive : " + notifActive);

        pauseMenu.SetActive(false);
        joystick.SetActive(true);
        iconeEncyclopedie.SetActive(true);
        iconeCarte.SetActive(true);
        boutonTir.SetActive(true);
        iconeRegroupement.SetActive(true);
        iconePause.SetActive(true);
        iconeHautFait.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);

    }

}
