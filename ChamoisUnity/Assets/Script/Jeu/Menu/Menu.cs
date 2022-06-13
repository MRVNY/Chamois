using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject resume;
    public Image menuIcon;
    public GameObject pasueIcon;
    public PauseMenu pause;
    
    public GameObject NotifMenuDeroulant ;
    public List<GameObject> ListeBoutons;
    public static bool menuOuvre = false;

    public GameObject ChapitreChamois;
    public GameObject ChapitreChassuer;
    public GameObject ChapitreRandonner;

    private void Awake()
    {
        SaveLoad.LoadState();
    }

    private void Start()
    {
        pause = GetComponent<PauseMenu>();
        RectTransform firstIcon = menuIcon.GetComponent<RectTransform>();
        Vector2 root = firstIcon.position;
        float length = firstIcon.rect.height;
        
        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].transform.position = new Vector2(root.x, root.y - (i+1) * length * 1.5f);
        }
        
        Deactivate();
    }

    public void activeMain()
    {
        NotifMenuDeroulant.SetActive(false);
        if (menuIcon.enabled)
        {
            Activate();
        }
        else
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1)
            {
                GOPointer.MenuManager.GetComponent<AudioSource>().Play();
            }
            Deactivate();
        }
    }
    
    public void Activate()
    {
        pause.Pause();
        
        resume.SetActive(true);
        menuIcon.enabled = false;
        pasueIcon.SetActive(true);
        
        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(true);
        }
        menuOuvre = true;
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GOPointer.MenuManager.GetComponent<AudioSource>().Play();
        }

    }
    
    public void Deactivate()
    {
        pause.Resume();
        
        resume.SetActive(false);
        menuIcon.enabled = true;
        pasueIcon.SetActive(false);

        ChapitreChamois.SetActive(false);
        ChapitreChassuer.SetActive(false);
        ChapitreRandonner.SetActive(false);
        
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GOPointer.MenuManager.GetComponent<AudioSource>().Play();
        }

        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(false);
        }

        menuOuvre = false;
    }
    
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Switch(string perso)
    {
        Global.Personnage = perso;
        SceneManager.LoadScene("Game");
    }

    public void EncyOnClick()
    {
        Vibrate.vibration();
        //GOPointer.Ouvre.SetActive(false);
        GOPointer.GameControl.GetComponent<GameControlScript>().setFalse();
        if (ChapitreChamois.activeSelf || ChapitreChassuer.activeSelf || ChapitreRandonner.activeSelf)
        {
            ChapitreChamois.SetActive(false);
            ChapitreChassuer.SetActive(false);
            ChapitreRandonner.SetActive(false);
            pasueIcon.SetActive(true);
        }
        else
        {
            if (Global.Personnage=="Chamois") ChapitreChamois.SetActive(true);
            else if (Global.Personnage=="Chasseur") ChapitreChassuer.SetActive(true);
            else if(Global.Personnage=="Randonneur") ChapitreRandonner.SetActive(true);
            pasueIcon.SetActive(false);
        }
    }
}
