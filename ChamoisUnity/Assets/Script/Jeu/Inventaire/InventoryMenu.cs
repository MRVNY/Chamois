using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] public GameObject inventoryMenu;
    /*[SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject iconeEncyclopedie;
    [SerializeField] private GameObject iconeCarte;
    [SerializeField] private GameObject boutonTir;*/

    public void activeInventory()
    {
        if (inventoryMenu.activeSelf)
        {
            inventaryOff();
            //GameObject.Find("CanvasItem").GetComponent<ListItems>().test();
        }
        else
        {
            inventaryOn();
        }
    }

    public void inventaryOn()
    {
        inventoryMenu.SetActive(true);
        /*pauseMenu.SetActive(false);
        joystick.SetActive(false);
        iconeEncyclopedie.SetActive(false);
        iconeCarte.SetActive(false);
        boutonTir.SetActive(false);*/
        Time.timeScale = 0f;
    }

    public void inventaryOff()
    {
        inventoryMenu.SetActive(false);
        /*pauseMenu.SetActive(true);
        joystick.SetActive(true);
        iconeEncyclopedie.SetActive(true);
        iconeCarte.SetActive(true);
        boutonTir.SetActive(true);*/
        Time.timeScale = 1f;
    }
}